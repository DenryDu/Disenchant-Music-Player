using Disenchant.Music.Model;
using Disenchant.Music.Models;
using Disenchant.Music.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Disenchant.Music.ViewModels
{
    internal class RootPlayBarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


        public RootPlayBarViewModel()
        {
            CurrentMusic = new MusicInfo();
            PlayBtnIcon = GlobalData.PlayBtnIcon;
            RootPlayBarView.GetProgressSlider().AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(GlobalData.AudioPlayer.ProgressLock), true);
            RootPlayBarView.GetProgressSlider().AddHandler(UIElement.PointerReleasedEvent, new PointerEventHandler(GlobalData.AudioPlayer.ProgressUpdate), true);
        }

        public static RootPlayBarView RootPlayBarView;

        private MusicInfo _currentMusic;
        public MusicInfo CurrentMusic
        {
            get { return _currentMusic; }
            set
            {
                if (_currentMusic != null)
                {
                    _currentMusic.Cover.DecodePixelHeight = 100; _currentMusic.Cover.DecodePixelWidth = 100;
                }
                _currentMusic = value;
                _currentMusic.Cover.DecodePixelWidth = 500; _currentMusic.Cover.DecodePixelHeight = 500;

                // Set Music Source for Player
                if (_currentMusic.Path != null)
                {
                    GlobalData.AudioPlayer.SetSource(_currentMusic.Path);
                }

                OnPropertyChanged(nameof(CurrentMusic));
            }
        }

        // BtnPlay
        private string _playBtnIcon;
        public string PlayBtnIcon { get { return _playBtnIcon; } set { _playBtnIcon = value; OnPropertyChanged(nameof(PlayBtnIcon)); } }

   
        internal void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMusic.Title != null)
            {
                if (PlayBtnIcon == GlobalData.PlayBtnIcon)
                {
                    /*
                    // Stop Last Song
                    if (AudioPlayer.AudioOutput != null && AudioPlayer.AudioOutput.PlaybackState == PlaybackState.Playing)
                    {
                        AudioPlayer.Stop();
                    }
                    */
                    // Play Latest Song
                    try
                    {
                        //AudioPlayer.SetAudioSource(GlobalData.MusicLibrary.GetMusicFile(CurrentMusic.Path));
                        PlayBtnIcon = GlobalData.PauseBtnIcon;
                        GlobalData.AudioPlayer.Play();
                    }
                    catch (Exception excep)
                    {

                    }
                }
                else
                {
                    PlayBtnIcon = GlobalData.PlayBtnIcon;
                    // TODO: Pause
                    GlobalData.AudioPlayer.Pause();
                }
            }
        }
    }
}
