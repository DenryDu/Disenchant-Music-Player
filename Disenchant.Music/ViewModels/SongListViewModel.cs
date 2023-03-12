using Disenchant.Music.Helpers;
using Disenchant.Music.Models;
using Disenchant.Music.Views;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disenchant.Music.ViewModels
{
    internal class SongListViewModel : INotifyPropertyChanged
    {
        // RootNavView 实例
        public static RootNavView RootNavView;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }



        public static RootPlayBarView RootPlayBarView;

        private ObservableCollection<MusicInfo> _songList;
        public ObservableCollection<MusicInfo> SongList { get { return _songList; } set { _songList = value; OnPropertyChanged(nameof(SongList)); } }

        private List<string> pathList = new List<string>();
        public SongListViewModel()
        {
            SongList = new ObservableCollection<MusicInfo>();
            SongList = GlobalData.MusicLibrary.Musics;
        }
        /*
        public void RefreshList()
        {
            
            foreach (string path in pathList)
            {
                SongList.Add(new MusicInfo(path));
                //OnPropertyChanged(nameof(SongList));
            }
        }
        */


        public void SonglistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                MusicInfo selectedMusic = ((ListView)sender).SelectedItem as MusicInfo;

            // First Time Select
            if (selectedMusic.Path != RootPlayBarView.RootPlayBarViewModel.CurrentMusic.Path)
            {

                Stopwatch stopwatch = new Stopwatch();
                Debug.WriteLine("new start:");

                // Play
                if (RootPlayBarView.RootPlayBarViewModel.CurrentMusic.Title != null)
                {
                    GlobalData.AudioPlayer.Stop();// Stop Before: 0.5254845 ==》 ？
                }

                RootPlayBarView.RootPlayBarViewModel.CurrentMusic = selectedMusic; // Set Current: 0.4373912 ==》 0.017505


                RootPlayBarView.RootPlayBarViewModel.PlayBtnIcon = GlobalData.PauseBtnIcon;
          
                GlobalData.AudioPlayer.Play(); // Play: 0.0000052 ==》
            }
            else  // Not First Time
            {
                //return;
            }
            //return;

        }
    }
}
