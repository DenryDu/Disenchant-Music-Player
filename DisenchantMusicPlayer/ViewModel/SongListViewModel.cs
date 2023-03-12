using DisenchantMusicPlayer.Helpers;
using DisenchantMusicPlayer.Model;
using DisenchantMusicPlayer.Player;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Audio;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DisenchantMusicPlayer.ViewModel
{
    internal class SongListViewModel : INotifyPropertyChanged
    {
        // MainPage 实例
        public static MainPage mainPage;

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
            MusicInfo selectedMusic = ((ListView)sender).SelectedItem as MusicInfo;

            // First Time Select
            if (selectedMusic.Path != mainPage.MainViewModel.CurrentMusic.Path) 
            {

                Stopwatch stopwatch = new Stopwatch();
                Debug.WriteLine("new start:");

                // Play
                if (mainPage.MainViewModel.CurrentMusic.Title != null)
                {
                    stopwatch = new Stopwatch();
                    stopwatch.Start();
                    GlobalData.AudioPlayer.Stop();// Stop Before: 0.5254845 ==》 ？
                    stopwatch.Stop();
                    Debug.WriteLine("stop():"+stopwatch.Elapsed.TotalSeconds);
                }

                //stopwatch = new Stopwatch();
                //stopwatch.Start();
                mainPage.MainViewModel.CurrentMusic = selectedMusic; // Set Current: 0.4373912 ==》 0.017505
                //stopwatch.Stop();
                //Debug.WriteLine("setsource():"+stopwatch.Elapsed.TotalSeconds);

                mainPage.MainViewModel.PlayBtnIcon = GlobalData.PauseBtnIcon;
                stopwatch = new Stopwatch();
                stopwatch.Start();
                GlobalData.AudioPlayer.Play(); // Play: 0.0000052 ==》
                stopwatch.Stop();
                Debug.WriteLine("play():"+ stopwatch.Elapsed.TotalSeconds);
                //return;
            }
            else  // Not First Time
            {
                // Go To Detail
                //return;

            }
            //return;

        }
    }
}
