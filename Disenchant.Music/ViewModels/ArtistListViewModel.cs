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
    class ArtistListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<ArtistInfo> _artistList;
        public ObservableCollection<ArtistInfo> ArtistList { get { return _artistList; } set { _artistList = value; OnPropertyChanged(nameof(ArtistList)); } }

        public ArtistListViewModel()
        {
            ArtistList = new ObservableCollection<ArtistInfo>(GlobalData.MusicLibrary.Artists.Values);
        }

    }
}
