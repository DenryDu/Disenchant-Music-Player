using Disenchant.Music.Views;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Threading;
using Windows.Media.Playback;
using Windows.Devices.Enumeration;
using Windows.Foundation.Collections;
using Windows.Media.Audio;
using Windows.Media.Devices;
using Windows.Media.Core;
using Disenchant.Music.Helpers;
using Windows.Storage;
using System.Collections.ObjectModel;
using Windows.UI.Input;
using System.Text.RegularExpressions;
using WinRT;
using System.Diagnostics;
using Windows.Foundation;

namespace Disenchant.Music.Models
{
    internal class MAudioPlayer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public static RootPlayBarView PlayBarUI;
        public static SongDetailView songDetailUI;

        public MAudioPlayer()
        {
            // Init PlayList
            PlayList = new List<string>();
            PlayListIdx = 0;
            PlayListLength = 0;
            PlayListMode = 0;

            // Init Current Music
            CurrentMusic = new MusicInfo();

            // Init Volume
            CurrentVolume = 100;

            // Init
            CurrentLyric = new ObservableCollection<LyricSlice>();
            CurrentLyricIndex = 0;
            InitMediaPlayer();
        }

        /// <summary>
        /// PlayList: List of Music Path
        /// </summary>
        private List<string> _playList;
        public List<string> PlayList { get { return _playList; } set { _playList = value; OnPropertyChanged(nameof(PlayList)); } }

        /// <summary>
        /// PlayListIdx: Index representing current Music
        /// </summary>
        private int _playListLength;
        public int PlayListLength { get { return _playListLength; } set { _playListLength = value; OnPropertyChanged(nameof(_playListLength)); } }

        /// <summary>
        /// PlayListIdx: Index representing current Music
        /// </summary>
        private int _playListIdx;
        public int PlayListIdx { get { return _playListIdx; } set { _playListIdx = value; OnPropertyChanged(nameof(_playListIdx)); } }

        /// <summary>
        /// Mode to Play Music in List: 0-shuffle, 1-repeat all, 2-repeat one
        /// </summary>
        private int _playListMode;
        public int PlayListMode { get { return _playListMode; } set { _playListMode = value; OnPropertyChanged(nameof(PlayListMode)); } }

        /// <summary>
        /// Mode to Play Music in List: 0-pause, 1-play
        /// </summary>
        private int _playState;
        public int PlayState { get { return _playState; } set { _playState = value; OnPropertyChanged(nameof(PlayState)); } }

        private List<int> _shuffleList;
        public List<int> ShuffleList { get { return _shuffleList; } set { _shuffleList = value; OnPropertyChanged(nameof(ShuffleList)); } }

        /// <summary>
        /// Current Music
        /// </summary>
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
                    SetSource(_currentMusic.Path);
                    CurrentLyric = LyricSlice.GetLyricSlices(CurrentMusic.Lyric);
                }

                OnPropertyChanged(nameof(CurrentMusic));
            }
        }
        private ObservableCollection<LyricSlice> _currentLyric;
        public ObservableCollection<LyricSlice> CurrentLyric { get { return _currentLyric; } set { _currentLyric = value; try { OnPropertyChanged(nameof(CurrentLyric)); } catch { } } }
        private int _currentLyricIndex;
        public int CurrentLyricIndex { get { return _currentLyricIndex; } set { _currentLyricIndex = value; OnPropertyChanged(nameof(CurrentLyricIndex)); } }
        
        //
        public MediaPlayer MediaPlayer { get; private set; }

        private DeviceInformation _autoDevice;

        private void InitMediaPlayer()
        {
            MediaPlayer = new MediaPlayer
            {
                AudioCategory = MediaPlayerAudioCategory.Media,
            };

            _autoDevice = MediaPlayer.AudioDevice;
            var type = MediaPlayer.AudioDeviceType;
            var mgr = MediaPlayer.CommandManager;
            mgr.IsEnabled = true;
        }
        public int GetCurrentLyricIndex(double currentTime)
        {
            var index = CurrentLyric.ToList().FindIndex(x => x.Time > currentTime);
            if (index > 0)
            {
                index--;
            }
            if (index < 0)
            {
                index = CurrentLyric.Count - 1;
            }
            return index;
        }
        /*
        /// <summary>
        /// WaveOutEvent: Sending audio to the soundcard, ease of use and broad platform support.
        /// </summary>
        private WaveOutEvent _outputDevice;
        private WasapiOut _wasapiOut;

        /// <summary>
        /// VolumeSampleProvider: Help Set the Volume
        /// </summary>
        private VolumeSampleProvider _volumeProvider;

        /// <summary>
        /// AudioFileReader: To load an audio file.This is a good choice as it supports several common audio file formats including WAV and MP3.
        /// </summary>
        private AudioFileReader _audioFile;

        */

        /// <summary>
        /// Timer Thread to Update Progress Position
        /// </summary>
        private ThreadPoolTimer positionUpdateTimer;

        /// <summary>
        /// Block Timer Thread when Set True
        /// </summary>
        private bool lockable = false;

        /// <summary>
        /// Audio Play Positon
        /// </summary>
        private TimeSpan _current;
        public TimeSpan Current { get { return _current; } set { _current = value; OnPropertyChanged(nameof(Current)); } }

        /// <summary>
        /// Audio Play Duration
        /// </summary>
        private TimeSpan _total;
        public TimeSpan Total { get { return _total; } set { _total = value; OnPropertyChanged(nameof(Total)); } }

        /// <summary>
        /// Audio Play Position Value (Percent 100f)
        /// </summary>
        private double _currentPosition;
        public double CurrentPosition { get { return _currentPosition; } set { _currentPosition = value; OnPropertyChanged(nameof(CurrentPosition)); } }

        /// <summary>
        /// Audio Play Volume Value (Percent 100f)
        /// </summary>
        private double _currentVolume;
        public double CurrentVolume { get { return _currentVolume; } set { _currentVolume = value; OnPropertyChanged(nameof(CurrentVolume)); } }

        // Lock to Restrict Access to MediaPlayer
        private readonly object mediaLock = new object();

        /// <summary>
        /// Setting Audio Source, and init _outputDevice and _audioFile if neccessary.
        /// </summary>
        /// <param name="path"></param>
        internal void SetSource(string path)
        {
            lock(mediaLock)
            {
                MediaPlayer = new MediaPlayer
                {
                    AudioCategory = MediaPlayerAudioCategory.Media,
                };
                MediaPlayer.Source = MediaSource.CreateFromStorageFile(AsyncHelper.RunSync(async () => { return await StorageFile.GetFileFromPathAsync(path); }));
                Total = MediaPlayer.PlaybackSession.NaturalDuration;
                //MediaPlayer.Volume
                MediaPlayer.Volume = CurrentVolume / 100d;
                positionUpdateTimer = ThreadPoolTimer.CreatePeriodicTimer(UpdatTimerHandler, TimeSpan.FromMilliseconds(100), UpdateTimerDestoyed);
                //MediaPlayer.PlaybackSession.PlaybackStateChanged += PlaybackSession_PlaybackStateChanged;
                MediaPlayer.MediaEnded += OnPlaybackStopped;
            }
        }
        /*
        private void PlaybackSession_PlaybackStateChanged(MediaPlaybackSession sender, object args)
        {
            // TODO: When error, restore
            
            if (MediaPlayer != null)
            {
                switch (MediaPlayer.PlaybackSession.PlaybackState)
                {
                    case MediaPlaybackState.None:
                        break;
                    case MediaPlaybackState.Opening:
                        break;
                    case MediaPlaybackState.Buffering:
                        break;
                    case MediaPlaybackState.Playing:
                        break;
                    case MediaPlaybackState.Paused: 
                        break;
                default:
                    break;

                }
            }
        }
        */
        internal void SetPlayList(List<MusicInfo> list)
        {
            PlayList = new List<string>();
            foreach (MusicInfo info in list)
            {
                PlayList.Add(info.Path);
            }
            PlayListLength = list.Count;

            // 生成Shuffle序列
            UpdateShuffle();

        }
        public void PlayListSongByPath(string path, bool forced = false)
        {
            lock (mediaLock)
            {
                if (CurrentMusic.Path != null)
                {
                    if (CurrentMusic.Path != path || forced)
                    {
                        Stop();
                        CurrentMusic = new MusicInfo(path); // Set Current: 0.4373912 ==》 0.017505
                        PlayListIdx = PlayList.FindIndex(p => p == path);
                        Play();
                    }
                }
                else
                {
                    CurrentMusic = new MusicInfo(path); // Set Current: 0.4373912 ==》 0.017505
                    PlayListIdx = PlayList.FindIndex(p => p == path);
                    Play();
                }
            }
            
        }


        /////////////////////////////////////////////////////////////////////   Play Control Start  /////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 播放
        /// </summary>
        internal void Play()
        {
            MediaPlayer.Play();
            PlayState = 1;
        }
        /// <summary>
        /// 暂停
        /// </summary>
        internal void Pause()
        {
            MediaPlayer.Pause();
            PlayState = 0;
        }
        /// <summary>
        /// 停止
        /// </summary>
        internal void Stop()
        {
            MediaPlayer.Pause();
            MediaPlayer.Dispose();
            positionUpdateTimer?.Cancel();
            positionUpdateTimer = null;
            //PlayState = 0;
        }
        /////////////////////////////////////////////////////////////////////    Play Control End    ///////////////////////////////////////////////////////////////////////////////





        /////////////////////////////////////////////////////////////////////   Event Handler Start   //////////////////////////////////////////////////////////////////////////////

        ///                 ///
        /// Progress Slider ///
        ///                 ///
        /// <summary>
        /// 堵塞更新计时器，为更新进度做准备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProgressLock(object sender, PointerRoutedEventArgs e)
        {
            lockable = true;
        }

        /// <summary>
        /// 更新进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProgressUpdate(object sender, PointerRoutedEventArgs e)
        {

            Pause();
            MediaPlayer.PlaybackSession.Position = TimeSpan.FromMilliseconds((double)((Slider)sender).Value * Total.TotalMilliseconds / 100d);
            UpdateProgressWhenLocked();
            lockable = false;
            Play();
        }

        ///               ///
        /// Volume Slider ///
        ///                ///   
        // 
        public void VolumeUpdate(object sender, RangeBaseValueChangedEventArgs e)
        {
            CurrentVolume = ((Slider)sender).Value;
            MediaPlayer.Volume = CurrentVolume / 100d;
        }

        ///                   ///
        /// PlayList Mode Btn ///
        ///                   ///   
        // 
        public void PlayListModeUpdate(object sender, RoutedEventArgs e)
        {
            PlayListMode = (PlayListMode + 1) % 3;
            if (PlayListMode == 0)
                UpdateShuffle();
        }

        ///               ///
        /// PlayPause Btn ///
        ///               ///   
        // 
        public void PlayPauseUpdate(object sender, RoutedEventArgs e)
        {
            if (PlayState == 1)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }

        public void PlayPreviousSong(object sender, RoutedEventArgs e)
        {
            switch (PlayListMode)
            {
                case 0:
                    int currentIdxInShuffle = ShuffleList.FindIndex(p => p == PlayListIdx);
                    // Shuffle
                    PlayListSongByPath(PlayList[ShuffleList[(currentIdxInShuffle + PlayListLength - 1) % PlayListLength]]);
                    return;
                case 1:
                    // Repeat All
                    PlayListSongByPath(PlayList[(PlayListIdx + PlayListLength - 1) % PlayListLength]);
                    return;
                case 2:
                    // Repeat One
                    PlayListSongByPath(PlayList[(PlayListIdx + PlayListLength - 1) % PlayListLength]);
                    return;
            }
        }

        public void PlayNextSong(object sender, RoutedEventArgs e)
        {
            switch (PlayListMode)
            {
                case 0:
                    int currentIdxInShuffle = ShuffleList.FindIndex(p => p == PlayListIdx);
                    // Shuffle
                    PlayListSongByPath(PlayList[ShuffleList[(currentIdxInShuffle + 1) % PlayListLength]]);
                    return;
                case 1:
                    // Repeat All
                    PlayListSongByPath(PlayList[(PlayListIdx + 1) % PlayListLength]);
                    return;
                case 2:
                    // Repeat One
                    PlayListSongByPath(PlayList[(PlayListIdx + 1) % PlayListLength]);
                    return;
            }
        }


        internal void CoverBtnClickToDetail(object sender, RoutedEventArgs e)
        {
            if (!GlobalData.IsDetail)
            {
                GlobalData.MainWindow.GetRootNavFrame().Navigate(typeof(SongDetailView));
                GlobalData.IsDetail = true;
            }
            else
            {
                GlobalData.MainWindow.GetRootNavFrame().GoBack();
                GlobalData.IsDetail = false;
            }
        }
        /////////////////////////////////////////////////////////////////////    Event Handler End   //////////////////////////////////////////////////////////////////////////////





        private void UpdateProgress()
        {
            lock (mediaLock)
            {
                if (MediaPlayer != null && !lockable && MediaPlayer.PlaybackSession.PlaybackState != MediaPlaybackState.None && MediaPlayer.PlaybackSession.PlaybackState == MediaPlaybackState.Playing && MediaPlayer.Source != null && PlayBarUI != null)
                {
                    PlayBarUI.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Low, () =>
                    {
                        Current = MediaPlayer.PlaybackSession?.Position ?? TimeSpan.Zero;
                        Total = MediaPlayer.PlaybackSession.NaturalDuration;
                        CurrentPosition = 100 * (Current.TotalMilliseconds / Total.TotalMilliseconds);
                    });
                    if(songDetailUI != null) {
                        songDetailUI.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Low, () =>
                        {
                            CurrentLyricIndex = GetCurrentLyricIndex((MediaPlayer.PlaybackSession?.Position ?? TimeSpan.Zero).TotalMilliseconds);
                            //songDetailUI.GetLyricViewer().
                            //Debug.WriteLine(songDetailUI.GetLyricStackPanel().Items[0].GetType());

                            /*
                            // 获取要定位之前 ScrollViewer 目前的滚动位置
                            var currentScrollPosition = songDetailUI.GetLyricViewer().VerticalOffset;
                            var point = new Point(0, currentScrollPosition);

                            // 计算出目标位置并滚动
                            var targetPosition = songDetailUI.GetCurrentLyricItem(CurrentLyricIndex).TransformToVisual(songDetailUI.GetLyricViewer()).TransformPoint(point);
                            songDetailUI.GetLyricViewer().ScrollToVerticalOffset(targetPosition.Y);
                            */
                        });
                    }    
                    
                }
            }
        }
        public double GetLyricFont(double itemTime, int CurrentLyricIdx)
        {
            try
            {
                if (itemTime == CurrentLyric[CurrentLyricIdx].Time)
                {
                    return 50d;
                }
                else
                {
                    return 20d;
                }
            }
            catch
            {
                return 20d;
            }
           
        }
        public Thickness GetLyricMargin(double itemTime, int CurrentLyricIdx)
        {
            try
            {
                if (itemTime == CurrentLyric[CurrentLyricIdx].Time)
                {
                    return new Thickness(0, 40, 0, 40);
                }
                else
                {
                    return new Thickness(0, 20, 0, 20);
                }
            }
            catch 
            { 
                return new Thickness(0, 20, 0, 20);
            }
        }
        public double GetLyricOpacity(double itemTime, int CurrentLyricIdx)
        {
            try
            {
                if (itemTime == CurrentLyric[CurrentLyricIdx].Time)
                {
                    return 1d;
                }
                else
                {
                    return .5d;
                }
            }
            catch
            {
                return .5d;
            }
         
        }
        private void UpdateProgressWhenLocked()
        {
            Current = MediaPlayer.PlaybackSession?.Position ?? TimeSpan.Zero;
            Total = MediaPlayer.PlaybackSession.NaturalDuration;
            CurrentPosition = 100 * (Current.TotalMilliseconds / Total.TotalMilliseconds);
        }

        // Timer Updater
        private void UpdatTimerHandler(ThreadPoolTimer timer)
        {
            UpdateProgress();
        }

        private void UpdateTimerDestoyed(ThreadPoolTimer timer)
        {
            timer.Cancel();
            timer = null;
            positionUpdateTimer?.Cancel();
            positionUpdateTimer = null;
        }

        private void OnPlaybackStopped(MediaPlayer sender, Object args)
        {
            PlayBarUI.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.High, () =>
                {
                    if (MediaPlayer.PlaybackSession.PlaybackState == MediaPlaybackState.Paused && !lockable)
                    {
                        switch (PlayListMode)
                        {
                            case 0:
                                int currentIdxInShuffle = ShuffleList.FindIndex(p => p == PlayListIdx);
                                // Shuffle
                                PlayListSongByPath(PlayList[ShuffleList[(currentIdxInShuffle + 1) % PlayListLength]]);
                                return;
                            case 1:
                                // Repeat All
                                PlayListSongByPath(PlayList[(PlayListIdx + 1) % PlayListLength]);
                                return;
                            case 2:
                                // Repeat One
                                PlayListSongByPath(PlayList[PlayListIdx], true);
                                return;
                        }
                    }
                });
        }

        internal void UpdateShuffle()
        {
            if (PlayList != null && PlayList.Count > 0)
            {
                ShuffleList = Enumerable.Range(0, PlayListLength).ToList().OrderBy(n => Guid.NewGuid()).ToList();
            }
        }

        ////////////////////////////////////////////////////////////////////////////   Display Converter   ////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Convert TimeSpan to String
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string TimeSpanConverter(TimeSpan value)
        {
            string temp = value.ToString().Split('.')[0];
            if (temp.Substring(1, 1) == "0")
                return temp.Substring(3, 5);
            else
                return temp;
        }
        /// <summary>
        /// Convert PlayListMode to BtnString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetPlayModeBtn(int value)
        {
            return GlobalData.PlayModeIcon[value];
        }

        public string GetPlayPauseBtn(int value)
        {
            return GlobalData.PlayPauseIcon[value];
        }

    }

    
}
