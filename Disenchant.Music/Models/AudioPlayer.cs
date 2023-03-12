using Disenchant.Music.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using NAudio.CoreAudioApi;
using NAudio.Utils;
using NAudio.Wave;
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

        public static RootPlayBarView PlayBarUI;

        /// <summary>
        /// WaveOutEvent: Sending audio to the soundcard, ease of use and broad platform support.
        /// </summary>
        private WaveOutEvent _outputDevice;

        /// <summary>
        /// _audioFileReader: To load an audio file.This is a good choice as it supports several common audio file formats including WAV and MP3.
        /// </summary>
        private AudioFileReader _audioFile;

        private bool lockable = false;

        private ThreadPoolTimer positionUpdateTimer;


        // test
        private TimeSpan _current;
        public TimeSpan Current { get { return _current; } set { _current = value; OnPropertyChanged(nameof(Current)); } }

        private TimeSpan _total;
        public TimeSpan Total { get { return _total; } set { _total = value; OnPropertyChanged(nameof(Total)); } }

        private double _currentPosition;
        public double CurrentPosition { get { return _currentPosition; } set { _currentPosition = value; OnPropertyChanged(nameof(CurrentPosition)); } }

        /// <summary>
        /// Setting Audio Source, and init _outputDevice and _audioFile if neccessary.
        /// </summary>
        /// <param name="path"></param>
        internal void SetSource(string path)
        {
            if (_outputDevice == null)
            {
                _outputDevice = new WaveOutEvent();
                //_outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (_audioFile == null)
            {
                // We then tell the output device to play audio from the audio file by using the Init method.
                // Finally, if all that is done, we can call Play on the output device.This method starts playback but won't wait for it to stop.
                _audioFile = new AudioFileReader(path);
                _outputDevice.Init(_audioFile);
            }
            Total = _audioFile.TotalTime;
            positionUpdateTimer = ThreadPoolTimer.CreatePeriodicTimer(UpdatTimerHandler, TimeSpan.FromMilliseconds(100), UpdateTimerDestoyed);
        }

        /// <summary>
        /// 播放
        /// </summary>
        internal void Play()
        {
            _outputDevice.Play();
        }
        /// <summary>
        /// 暂停
        /// </summary>
        internal void Pause()
        {
            _outputDevice.Pause();
        }
        /// <summary>
        /// 停止
        /// </summary>
        internal void Stop() {
            _outputDevice?.Stop();
            this.Destory();
        }


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

            _audioFile.CurrentTime = TimeSpan.FromMilliseconds(((Slider)sender).Value * Total.TotalMilliseconds / 100);

            UpdateProgress();

            lockable = false;
        }

        private void UpdateProgress()
        {
            if (_outputDevice != null && !lockable && _outputDevice.PlaybackState == PlaybackState.Playing && _audioFile != null && PlayBarUI != null)
            {
                PlayBarUI.DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.High, () =>
                {
                    Current = _audioFile?.CurrentTime ?? TimeSpan.Zero;
                    Total = _audioFile.TotalTime;
                    CurrentPosition = 100 * (Current.TotalMilliseconds / Total.TotalMilliseconds);
                });
            }
        }
        public AudioPlayer() {}
  
        
        private void UpdatTimerHandler(ThreadPoolTimer timer) { UpdateProgress(); }
  
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
            this.Destory();
        }
        private void Destory()
        {
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
            /*
            positionUpdateTimer?.Cancel();
            positionUpdateTimer = null;
            Current = TimeSpan.Zero;
            Total = TimeSpan.Zero;
            CurrentPosition = 0;
            */
        }

        public string TimeSpanConverter(TimeSpan value)
        {
            string temp = value.ToString().Split('.')[0];
            if (temp.Substring(1, 1) == "0")
                return temp.Substring(3, 5);
            else
                return temp;
        }
        
    }
}
