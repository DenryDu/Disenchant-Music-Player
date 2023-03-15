using Disenchant.Music.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disenchant.Music.ViewModels
{
    class AlbumListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<AlbumInfo> _albumList;
        public ObservableCollection<AlbumInfo> AlbumList { get { return _albumList; } set { _albumList = value; OnPropertyChanged(nameof(AlbumList)); } }

        public AlbumListViewModel() {
            AlbumList = new ObservableCollection<AlbumInfo>(GlobalData.MusicLibrary.Albums.Values);
        }
    }
}
