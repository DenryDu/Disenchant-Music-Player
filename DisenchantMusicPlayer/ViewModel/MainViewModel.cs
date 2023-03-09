using DisenchantMusicPlayer.Helpers;
using DisenchantMusicPlayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

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
       

        public MusicInfo CurrentMusic { 
            get { return _currentMusic; } 
            set {
                if (_currentMusic != null)
                {
                    _currentMusic.Cover.DecodePixelHeight = 100; _currentMusic.Cover.DecodePixelWidth = 100;
                }                
                _currentMusic = value;
                _currentMusic.Cover.DecodePixelWidth = 500; _currentMusic.Cover.DecodePixelHeight = 500; 
                OnPropertyChanged(nameof(CurrentMusic)); 
            } 
        }
    }
}
