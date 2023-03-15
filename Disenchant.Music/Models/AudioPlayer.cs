﻿using Disenchant.Music.Models;
using Disenchant.Music.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using NAudio.CoreAudioApi;
using NAudio.Utils;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Media.Playback;
using Windows.System.Threading;
//using System.Web.UI;
namespace Disenchant.Music.Model
{
    internal class AudioPlayer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public bool CanPlay;

        public AudioPlayer() 
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

            // Init Timer
            positionUpdateTimer = ThreadPoolTimer.CreatePeriodicTimer(UpdatTimerHandler, TimeSpan.FromMilliseconds(100), UpdateTimerDestoyed);
        }

        public static RootPlayBarView PlayBarUI;

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
                }
                OnPropertyChanged(nameof(CurrentMusic));
            }
        }

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

        /// <summary>
        /// Setting Audio Source, and init _outputDevice and _audioFile if neccessary.
        /// </summary>
        /// <param name="path"></param>
        internal void SetSource(string path)
        {
            /*
            if (_outputDevice == null)
            {
                _outputDevice = new WaveOutEvent();
                _wasapiOut = new WasapiOut();
                _outputDevice.NumberOfBuffers = 20;
                _outputDevice.DesiredLatency = 1000;
                _outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (_audioFile == null)
            {
                // We then tell the output device to play audio from the audio file by using the Init method.
                // Finally, if all that is done, we can call Play on the output device.This method starts playback but won't wait for it to stop.
                _audioFile = new AudioFileReader(path);
                //_audioFile.Buff
                // dsp start
                _volumeProvider = new VolumeSampleProvider(_audioFile)
                {
                    Volume = (float)CurrentVolume/100f
                };
                // dsp end

                // Connect
                _outputDevice.Init(_volumeProvider);
                _wasapiOut.Init(_volumeProvider);
            }
            Total = _audioFile.TotalTime;
            */
            if (_wasapiOut == null)
            {
                _wasapiOut = new WasapiOut();
                _wasapiOut.PlaybackStopped += OnPlaybackStopped;
            }
            if (_audioFile == null)
            {
                // We then tell the output device to play audio from the audio file by using the Init method.
                // Finally, if all that is done, we can call Play on the output device.This method starts playback but won't wait for it to stop.
                _audioFile = new AudioFileReader(path);
                //_audioFile.Buff
                // dsp start
                _volumeProvider = new VolumeSampleProvider(_audioFile)
                {
                    Volume = (float)CurrentVolume / 100f
                };
                // dsp end

                // Connect
                _wasapiOut.Init(_volumeProvider);
            }
            Total = _audioFile.TotalTime;
        }
        internal void SetPlayList(List<MusicInfo> list)
        {
            PlayList = new List<string>();
            foreach(MusicInfo info in list)
            {
                PlayList.Add(info.Path);
            }
            PlayListLength = list.Count;

            // 生成Shuffle序列
            UpdateShuffle();

        }
        public void PlayListSongByPath(string path, bool forced = false)
        {
            // First Time Select
            if (CurrentMusic.Path != path && CurrentMusic.Path != null)
            {
                // Stop
                Stop();// Stop Before: 0.5254845 ==》 ？
            }
            // 如果强制重复当前歌曲
            if (forced)
                Stop();

            // Set
            CurrentMusic = new MusicInfo(path); // Set Current: 0.4373912 ==》 0.017505
            PlayListIdx = PlayList.FindIndex(p => p == path);

            // Play
            Play();
        }


        /////////////////////////////////////////////////////////////////////   Play Control Start  /////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 播放
        /// </summary>
        internal void Play()
        {
            //_outputDevice.Play();
            _wasapiOut.Play();
            PlayState = 1;
        }
        /// <summary>
        /// 暂停
        /// </summary>
        internal void Pause()
        {
            //_outputDevice.Pause();
            _wasapiOut.Pause();
            PlayState = 0;
        }
        /// <summary>
        /// 停止
        /// </summary>
        internal void Stop() {
            //_outputDevice?.Stop();
            _wasapiOut?.Stop();
            this.Destory();
            PlayState = 0;
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
            //RePositionSongByPath(CurrentMusic.Path, TimeSpan.FromMilliseconds((double)((Slider)sender).Value * Total.TotalMilliseconds / 100d), true);
            //_audioFile.CurrentTime = TimeSpan.FromMilliseconds((double)((Slider)sender).Value * Total.TotalMilliseconds / 100d);
            _audioFile.SetPosition(TimeSpan.FromMilliseconds((double)((Slider)sender).Value * Total.TotalMilliseconds / 100d).TotalSeconds);
            //UpdateProgressWhenLocked();
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
            if(_volumeProvider != null)
            {
                _volumeProvider.Volume = (float)CurrentVolume/100f;
            }
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
            if(PlayState == 1)
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
                    PlayListSongByPath(PlayList[(PlayListIdx + PlayListLength - 1)%PlayListLength]);
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
                    PlayListSongByPath(PlayList[ShuffleList[(currentIdxInShuffle+1)%PlayListLength]]);
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
        /////////////////////////////////////////////////////////////////////    Event Handler End   //////////////////////////////////////////////////////////////////////////////





        private void UpdateProgress()
        {
            //if (_outputDevice != null && !lockable && _outputDevice.PlaybackState == PlaybackState.Playing && _audioFile != null && PlayBarUI != null)
            if (_wasapiOut != null && !lockable && _wasapiOut.PlaybackState == PlaybackState.Playing && _audioFile != null && PlayBarUI != null)
            {
                PlayBarUI.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Low, () =>
                {
                    Current = _audioFile?.CurrentTime ?? TimeSpan.Zero;
                    Total = _audioFile.TotalTime;
                    CurrentPosition = 100 * (Current.TotalMilliseconds / Total.TotalMilliseconds);
                });
            }
        }
        private void UpdateProgressWhenLocked()
        {
            //if (_outputDevice != null && _outputDevice.PlaybackState == PlaybackState.Playing && _audioFile != null && PlayBarUI != null)
            //{
            //    PlayBarUI.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.High, () =>
            //    {
                    Current = _audioFile?.CurrentTime ?? TimeSpan.Zero;
                    Total = _audioFile.TotalTime;
                    CurrentPosition = 100 * (Current.TotalMilliseconds / Total.TotalMilliseconds);
            //    });
            //}
        }

        // Timer Updater
        private void UpdatTimerHandler(ThreadPoolTimer timer) { 
            UpdateProgress();
        }
  
        private void UpdateTimerDestoyed(ThreadPoolTimer timer)
        {
            timer.Cancel();
            timer = null;
            positionUpdateTimer?.Cancel();
            positionUpdateTimer = null;
            //positionUpdateTimer = ThreadPoolTimer.CreatePeriodicTimer(UpdatTimerHandler, TimeSpan.FromMilliseconds(100), UpdateTimerDestoyed);
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            
            //if(_outputDevice.PlaybackState == PlaybackState.Stopped && !lockable)
            if(_wasapiOut.PlaybackState == PlaybackState.Stopped && !lockable)
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
            //this.Destory();   
        }
        private void Destory()
        {
            /*
            if (_outputDevice != null)
            {
                _outputDevice.Dispose();
                _outputDevice = null;
            }
            if (_audioFile != null)
            {
                _audioFile.Dispose();
                _audioFile = null;
            }
            */
            if (_wasapiOut != null)
            {
                _wasapiOut.Dispose();
                _wasapiOut = null;
            }
            if (_audioFile != null)
            {
                _audioFile.Dispose();
                _audioFile = null;
            }
        }

        internal void UpdateShuffle()
        {
            if(PlayList != null && PlayList.Count > 0)
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

    // new
    public static class WaveStreamExtensions
    {
        // Set position of WaveStream to nearest block to supplied position
        public static void SetPosition(this WaveStream strm, long position)
        {
            // distance from block boundary (may be 0)
            long adj = position % strm.WaveFormat.BlockAlign;
            // adjust position to boundary and clamp to valid range
            long newPos = Math.Max(0, Math.Min(strm.Length, position - adj));
            // set playback position
            strm.Position = newPos;
        }

        // Set playback position of WaveStream by seconds
        public static void SetPosition(this WaveStream strm, double seconds)
        {
            strm.SetPosition((long)(seconds * strm.WaveFormat.AverageBytesPerSecond));
        }

        // Set playback position of WaveStream by time (as a TimeSpan)
        public static void SetPosition(this WaveStream strm, TimeSpan time)
        {
            strm.SetPosition(time.TotalSeconds);
        }

        // Set playback position of WaveStream relative to current position
        public static void Seek(this WaveStream strm, double offset)
        {
            strm.SetPosition(strm.Position + (long)(offset * strm.WaveFormat.AverageBytesPerSecond));
        }
    }
}