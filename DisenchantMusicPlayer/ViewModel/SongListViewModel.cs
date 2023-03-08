using DisenchantMusicPlayer.Helpers;
using DisenchantMusicPlayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DisenchantMusicPlayer.ViewModel
{
    internal class SongListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        private ObservableCollection<MusicInfo> _songList;
        public ObservableCollection<MusicInfo> SongList { get { return _songList;  } set { _songList = value; OnPropertyChanged(nameof(SongList)); } }
        public SongListViewModel() 
        { 
            SongList = GlobalData.MusicLibrary.Musics;
        }
        public void SonglistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 要告知MainViewModel
            GlobalData.CurrentMusic = ((ListView)sender).SelectedItem as MusicInfo;
            //MainPage.ControllerCover.Source = GlobalData.CurrentMusic.Cover;

        }
    }
}
