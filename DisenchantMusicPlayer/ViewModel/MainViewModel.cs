using DisenchantMusicPlayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisenchantMusicPlayer.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public MainViewModel() { 
            CurrentMusic = new MusicInfo();
            //CurrentMusic.Cover = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("./Assets/StoreLogo.png"));
        }
        private MusicInfo _currentMusic;
       
        public MusicInfo CurrentMusic { get { return _currentMusic; } set { _currentMusic = value; OnPropertyChanged(nameof(CurrentMusic)); } }


    }
}
