using DisenchantMusicPlayer.Helpers;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Input;
using Windows.Media.Audio;
using Windows.Media.Render;
using Windows.Storage;


namespace DisenchantMusicPlayer.Player
{
    public class AudioPlayer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


        private AudioGraph _graph;
        public AudioGraph Graph { get { return _graph; } set { _graph = value; OnPropertyChanged(nameof(Graph));} }


        private AudioFileInputNode _fileInputNode;
        public AudioFileInputNode FileInputNode { get { return _fileInputNode; } set { _fileInputNode = value; OnPropertyChanged(nameof(FileInputNode)); } }


        private AudioDeviceOutputNode _deviceOutputNode;
        public AudioDeviceOutputNode DeviceOutputNode { get { return _deviceOutputNode; } set { _deviceOutputNode = value; } }

        private CreateAudioGraphResult result;
        private CreateAudioDeviceOutputNodeResult deviceOutputNodeResult;

        public void SetAudioSource(StorageFile file)
        {
            CreateAudioFileInputNodeResult fileInputResult = AsyncHelper.RunSync(async () => { return await Graph.CreateFileInputNodeAsync(file); });
            /*
            if (AudioFileNodeCreationStatus.Success != fileInputResult.Status)
            {
                // Cannot read input file
                //rootPage.NotifyUser(String.Format("Cannot read input file because {0}", fileInputResult.Status.ToString()), NotifyType.ErrorMessage);
                return;
            }
            */
            FileInputNode = fileInputResult.FileInputNode;
            /*
            if (FileInputNode.Duration <= TimeSpan.FromSeconds(3))
            {
                // Imported file is too short
                //rootPage.NotifyUser("Please pick an audio file which is longer than 3 seconds", NotifyType.ErrorMessage);

                // Reset InputNode
                FileInputNode.Dispose();
                FileInputNode = null;
                return;
            }
            */

            // Connect Input and Output
            FileInputNode.AddOutgoingConnection(DeviceOutputNode);
            //fileButton.Background = new SolidColorBrush(Colors.Green);

            // Trim the file: set the start time to 3 seconds from the beginning
            // fileInput.EndTime can be used to trim from the end of file
            //FileInputNode.StartTime = TimeSpan.FromSeconds(3);
            FileInputNode.StartTime = TimeSpan.FromSeconds(0);

            // Enable buttons in UI to start graph, loop and change playback speed factor
            //graphButton.IsEnabled = true;
            //loopToggle.IsEnabled = true;
            //playSpeedSlider.IsEnabled = true;
        }
        public async Task AsyncSetAudioSource(StorageFile file)
        {
            CreateAudioFileInputNodeResult fileInputResult = await Graph.CreateFileInputNodeAsync(file);
            /*
            if (AudioFileNodeCreationStatus.Success != fileInputResult.Status)
            {
                // Cannot read input file
                //rootPage.NotifyUser(String.Format("Cannot read input file because {0}", fileInputResult.Status.ToString()), NotifyType.ErrorMessage);
                return;
            }
            */
            FileInputNode = fileInputResult.FileInputNode;
            /*
            if (FileInputNode.Duration <= TimeSpan.FromSeconds(3))
            {
                // Imported file is too short
                //rootPage.NotifyUser("Please pick an audio file which is longer than 3 seconds", NotifyType.ErrorMessage);

                // Reset InputNode
                FileInputNode.Dispose();
                FileInputNode = null;
                return;
            }
            */

            // Connect Input and Output
            FileInputNode.AddOutgoingConnection(DeviceOutputNode);
            //fileButton.Background = new SolidColorBrush(Colors.Green);

            // Trim the file: set the start time to 3 seconds from the beginning
            // fileInput.EndTime can be used to trim from the end of file
            //FileInputNode.StartTime = TimeSpan.FromSeconds(3);
            FileInputNode.StartTime = TimeSpan.FromSeconds(0);

            // Enable buttons in UI to start graph, loop and change playback speed factor
            //graphButton.IsEnabled = true;
            //loopToggle.IsEnabled = true;
            //playSpeedSlider.IsEnabled = true;
            return;
        }
        public void Init()
        {
            // Create an AudioGraph with default settings
            AudioGraphSettings settings = new AudioGraphSettings(AudioRenderCategory.Media);
            //CreateAudioGraphResult result = AsyncHelper.RunSync(async()=> { return await AudioGraph.CreateAsync(settings); });
            result = AsyncHelper.RunSync(async()=> { return await AudioGraph.CreateAsync(settings); });

            if (result.Status != AudioGraphCreationStatus.Success)
            {
                // Cannot create graph
                //rootPage.NotifyUser(String.Format("AudioGraph Creation Error because {0}", result.Status.ToString()), NotifyType.ErrorMessage);
                return;
            }

            Graph = result.Graph;

            // Create a device output node
            //CreateAudioDeviceOutputNodeResult deviceOutputNodeResult = AsyncHelper.RunSync(async () => { return await Graph.CreateDeviceOutputNodeAsync(); });
            deviceOutputNodeResult = AsyncHelper.RunSync(async () => { return await Graph.CreateDeviceOutputNodeAsync(); });

            if (deviceOutputNodeResult.Status != AudioDeviceNodeCreationStatus.Success)
            {
                // Cannot create device output node
                //rootPage.NotifyUser(String.Format("Device Output unavailable because {0}", deviceOutputNodeResult.Status.ToString()), NotifyType.ErrorMessage);
                //speakerContainer.Background = new SolidColorBrush(Colors.Red);
                return;
            }

            DeviceOutputNode = deviceOutputNodeResult.DeviceOutputNode;
            //rootPage.NotifyUser("Device Output Node successfully created", NotifyType.StatusMessage);
            //speakerContainer.Background = new SolidColorBrush(Colors.Green);
        }

        public void Play()
        {
            Graph.Start();
        }

        public void Pause()
        {
            Graph.Stop();
        }

        public void Stop()
        {
            Debug.WriteLine(FileInputNode.Position);
            FileInputNode.Dispose();
        }



        /// <summary>
        /// WasapiOutRT
        /// </summary>
        /*
        private WasapiOutRT _audioOutput;
        public WasapiOutRT AudioOutput { get { return _audioOutput; } set { _audioOutput = value; } }
        public bool SetAudioSource1(StorageFile file)
        {
            if (file != null)
            {
                try
                {
                    var stream = AsyncHelper.RunSync(async () => { return await file.OpenAsync(FileAccessMode.Read); });

                    _audioOutput = new WasapiOutRT(AudioClientShareMode.Shared, 200);
                    _audioOutput.Init(() =>
                    {
                        var waveChannel32 = new WaveChannel32(new StreamMediaFoundationReader(stream.AsStream()));
                        var mixer = new MixingSampleProvider(new ISampleProvider[] { waveChannel32.ToSampleProvider() });
                        return mixer.ToWaveProvider();
                    });
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;

        }

        public void Play1()
        {
            _audioOutput.Play();
        }
        public void Pause1()
        {
            _audioOutput.Pause();
        }
        public void Stop1()
        {
            _audioOutput.Stop();
        }
        */


        /*

        private IWavePlayer _device;
        private AudioFileReader _reader;

        private VolumeSampleProvider _volumeProvider;

        private CancellationTokenSource _cts;

        private bool _sliderLock; // 逻辑锁，当为true时不更新界面上的进度

 




        private void btnOpen_Click(object sender, EventArgs e)
        {


            try
            {
                string filename;

                StorageFile file;
                WaveOut;
                _device = new WaveOutEvent(); // Create device
                _reader = new AudioFileReader(file); // Create reader


                var stream = AsyncHelper.RunSync(async () => { return await file.OpenAsync(FileAccessMode.Read); });

                _audioOutput = new WasapiOutRT(AudioClientShareMode.Shared, 200);
                _audioOutput.Init(() =>
                {
                    var waveChannel32 = new WaveChannel32(new StreamMediaFoundationReader(stream.AsStream()));
                    var mixer = new MixingSampleProvider(new ISampleProvider[] { waveChannel32.ToSampleProvider() });
                    return mixer.ToWaveProvider();
                });

                _reader = AsyncHelper.RunSync(() =>
                {
                    var waveChannel32 = new WaveChannel32(new StreamMediaFoundationReader(stream.AsStream()));
                    var mixer = new MixingSampleProvider(new ISampleProvider[] { waveChannel32.ToSampleProvider() });
                    return mixer.ToWaveProvider();
                })


                // dsp start
                _volumeProvider = new VolumeSampleProvider(_reader)
                {
                    Volume = sliderVolume.Value / 100f
                };
                // dsp end



                _device.Init(_volumeProvider);
                //_device.Init(_reader); // 之前是reader，现改为VolumeSampleProvider
                // https://stackoverflow.com/questions/46433790/how-to-chain-together-multiple-naudio-isampleprovider-effects

                var duration = _reader.TotalTime; // 总时长
                sliderProgress.Maximum = (int)duration.TotalMilliseconds;
                lblDuration.Text = duration.ToString(@"mm\:ss");

                _cts = new CancellationTokenSource();
                StartUpdateProgress(); // 界面更新线程

                _device.PlaybackStopped += Device_OnPlaybackStopped;
            }
            catch (Exception ex)
            {
                DisposeAll();
                MessageBox.Show(ex.Message);
            }
        }

        private void sliderProgress_MouseDown(object sender, MouseEventArgs e)
        {
            _sliderLock = true; // 拖动开始，停止更新界面
        }

        private void sliderProgress_MouseUp(object sender, MouseEventArgs e)
        {
            // 释放鼠标时，应用目标进度
            _reader.CurrentTime = TimeSpan.FromMilliseconds(sliderProgress.Value);
            UpdateProgress();
            _sliderLock = false; // 拖动结束，恢复更新界面
        }

        private void sliderProgress_ValueChanged(object sender, EventArgs e)
        {
            if (_sliderLock)
            {
                // 拖动时可以直观看到目标进度
                lblPosition.Text = TimeSpan.FromMilliseconds(sliderProgress.Value).ToString(@"mm\:ss");
            }
        }

        private void sliderVolume_ValueChanged(object sender, EventArgs e)
        {
            UpdateVolume();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void Form_Closed(object sender, EventArgs e)
        {
            DisposeAll();
        }

        private void Device_OnPlaybackStopped(object obj, StoppedEventArgs arg)
        {
            StopAction();
        }

        private void StartUpdateProgress()
        {
            // 此处可用Timer完成而不是手动循环，但不建议使用UI线程上的Timer
            Task.Run(() =>
            {
                while (!_cts.IsCancellationRequested)
                {
                    if (_device.PlaybackState == PlaybackState.Playing)
                    {
                        // 若为播放状态，持续更新界面
                        BeginInvoke(new Action(UpdateProgress));
                        Thread.Sleep(100);
                    }
                    else
                    {
                        Thread.Sleep(50);
                    }
                }
            });
        }

        /// <summary>
        /// Stop
        /// </summary>
        private void StopAction()
        {
            _device?.Stop();
            if (_reader != null) _reader.Position = 0;
            UpdateProgress();
        }

        /// <summary>
        /// Play
        /// </summary>
        private void PlayAction()
        {
            _device?.Play();
        }

        /// <summary>
        /// Pause
        /// </summary>
        private void PauseAction()
        {
            _device?.Pause();
        }

        private void UpdateProgress()
        {
            var currentTime = _reader?.CurrentTime ?? TimeSpan.Zero; // 当前时间
            Console.WriteLine(currentTime);

            if (!_sliderLock)
            {
                sliderProgress.Value = (int)currentTime.TotalMilliseconds;
                lblPosition.Text = currentTime.ToString(@"mm\:ss");
            }
        }

        private void UpdateVolume()
        {
            var volume = sliderVolume.Value / 100f;
            _volumeProvider.Volume = volume;
            //if (_device != null) _device.Volume = volume;  // 注释这一句
        }

        private void DisposeDevice()
        {
            if (_device != null)
            {
                _device.PlaybackStopped -= Device_OnPlaybackStopped;
                _device.Dispose();
            }
        }

        private void DisposeAll()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _reader?.Dispose();
            DisposeDevice();
        }
        */
    }
}





