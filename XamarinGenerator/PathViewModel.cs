using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamarinGenerator.Annotations;

namespace XamarinGenerator
{
    class PathViewModel : INotifyPropertyChanged
    {
        private string _iconPath;
        private string _launchPath;
        private string _exportDirectory;

        public string IconPath
        {
            get { return _iconPath; }
            set
            {
                if (value == _iconPath) return;
                _iconPath = value;
                OnPropertyChanged();
            }
        }

        public string LaunchPath
        {
            get { return _launchPath; }
            set
            {
                if (value == _launchPath) return;
                _launchPath = value;
                OnPropertyChanged();
            }
        }

        public string ExportDirectory
        {
            get { return _exportDirectory; }
            set
            {
                if (value == _exportDirectory) return;
                _exportDirectory = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
