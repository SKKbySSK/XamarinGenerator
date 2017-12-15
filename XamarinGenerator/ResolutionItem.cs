using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinGenerator
{
    public class ResolutionItem
    {
        public ResolutionItem(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            Export = true;
        }

        public ResolutionItem(int Size)
        {
            Width = Size;
            Height = Size;
            Export = true;
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public bool Export { get; set; }
    }
}
