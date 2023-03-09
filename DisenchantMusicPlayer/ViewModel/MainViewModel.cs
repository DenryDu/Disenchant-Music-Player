using DisenchantMusicPlayer.Helpers;
using DisenchantMusicPlayer.Model;
using DisenchantMusicPlayer.View;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.MediaFoundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using muxc = Microsoft.UI.Xaml.Controls;
using System.IO;
using DisenchantMusicPlayer.Player;

namespace DisenchantMusicPlayer.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public static MainPage mainPage;
        // List of ValueTuple holding the Navigation Tag and the relative Navigation Page
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("songlist", typeof(SongListPage)),
            ("albumlist", typeof(AlbumListPage)),
            ("artistlist", typeof(ArtistListPage)),
            ("playlist", typeof(PlayListPage)),
            ("settings", typeof(SettingsPage)),
        };
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
                AudioPlayer.SetAudioSource(GlobalData.MusicLibrary.GetMusicFile(CurrentMusic.Path));

                OnPropertyChanged(nameof(CurrentMusic));
            }
        }
        private StorageFile _currentMusicFile;
        public StorageFile CurrentMusicFile { get { return _currentMusicFile; } set { _currentMusicFile = value; OnPropertyChanged(nameof(CurrentMusicFile)); } }
        private string _playBtnIcon;
        public string PlayBtnIcon { get { return _playBtnIcon; } set { _playBtnIcon = value; OnPropertyChanged(nameof(PlayBtnIcon)); } }

        public MainViewModel() { 
            CurrentMusic = new MusicInfo();
            //CurrentMusicFile = new StorageFile();
            //CurrentMusic.Cover = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("./Assets/StoreLogo.png"));
            PlayBtnIcon = GlobalData.PlayBtnIcon;
        }
        
        

        // Navigation
        internal void NavView_ItemInvoked(muxc.NavigationView sender,
                                      muxc.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }
        internal void NavView_Navigate(
            string navItemTag,
            Windows.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")
            {
                _page = typeof(SettingsPage);
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }
            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = mainPage.GetFrame().CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                mainPage.GetFrame().Navigate(_page, null, transitionInfo);
            }
        }




        // PlayControl-Play-Pause
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
                        AudioPlayer.Play();
                    }
                    catch(Exception excep)
                    {

                    }              
                }
                else
                {
                    PlayBtnIcon = GlobalData.PlayBtnIcon;
                    // TODO: Pause
                    AudioPlayer.Pause();
                }
            }          
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
