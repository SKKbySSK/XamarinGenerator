using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace XamarinGenerator
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PathViewModel pathVM;
        private readonly FolderBrowserDialog fbd = new FolderBrowserDialog();
        private readonly OpenFileDialog ofd = new OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();

            pathVM = (PathViewModel)Resources["pathVM"];

            fbd.SelectedPath = pathVM.ExportDirectory;
            ofd.FileName = pathVM.IconPath;
        }

        private void iosExportB_Click(object sender, RoutedEventArgs e)
        {
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            pathVM.ExportDirectory = fbd.SelectedPath;

            iOSViewModel ios = (iOSViewModel) Resources["iosVM"];

            if (File.Exists(pathVM.IconPath))
            {
                string bname = Path.GetFileNameWithoutExtension(pathVM.IconPath);
                Directory.CreateDirectory(Path.Combine(fbd.SelectedPath, "Icons"));
                using (Image img = Image.FromFile(pathVM.IconPath))
                {
                    foreach (var res in ios.IconRes)
                    {
                        if (res.Export)
                        {
                            using (var resized = ResizeBitmap(img, res.Width, res.Height))
                            {
                                resized.Save(Path.Combine(fbd.SelectedPath, "Icons", bname + res.Width + ".png"));
                            }
                        }
                    }
                }
            }

            if (File.Exists(pathVM.LaunchPath))
            {
                string bname = Path.GetFileNameWithoutExtension(pathVM.LaunchPath);
                Directory.CreateDirectory(Path.Combine(fbd.SelectedPath, "Launch"));
                using (Image img = Image.FromFile(pathVM.LaunchPath))
                {
                    foreach (var res in ios.LaunchRes)
                    {
                        if (res.Export)
                        {
                            using (var center = CenterBitmap(img, res.Width, res.Height))
                            {
                                center.Save(Path.Combine(fbd.SelectedPath, "Launch", bname + res.Width + ".png"));
                            }
                        }
                    }
                }
            }
        }

        Bitmap ResizeBitmap(Image Image, int Width, int Height)
        {
            Bitmap res = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(res))
            {
                g.DrawImage(Image, 0, 0, Width, Height);
            }
            return res;
        }

        Bitmap CenterBitmap(Image Image, int Width, int Height)
        {
            Bitmap res = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(res))
            {
                double width = Width, height = Height;
                double rw = Image.Width / (double)Width, rh = Image.Height / (double)Height, r = Math.Min(rw, rh);
                width *= r;
                height *= r;

                double x = (Image.Width - width) / 2;
                double y = (Image.Height - height) / 2;

                g.DrawImage(Image, new Rectangle(0, 0, Width, Height), new Rectangle((int)x, (int)y, (int)(width), (int)(height)), GraphicsUnit.Pixel);
            }
            return res;
        }

        private void iconB_Click(object sender, RoutedEventArgs e)
        {
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                pathVM.IconPath = ofd.FileName;
        }

        private void launchB_Click(object sender, RoutedEventArgs e)
        {
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                pathVM.LaunchPath = ofd.FileName;
        }
    }
}
