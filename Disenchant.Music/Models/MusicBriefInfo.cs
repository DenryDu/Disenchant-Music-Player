using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disenchant.Music.Models
{
    class MusicBriefInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private string _path;
        public string Path { get { return _path; } set { _path = value; OnPropertyChanged(nameof(Path)); } }

        private string _title;
        public string Title { get { return _title; } set { _title = value; OnPropertyChanged(nameof(_title)); } }

        public MusicBriefInfo(string path, string title)
        {
            Path = path;
            Title = title;
        }
    }
}
