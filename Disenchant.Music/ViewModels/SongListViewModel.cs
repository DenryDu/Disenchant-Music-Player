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
        public ObservableCollection<MusicInfo> SongList { get { return _songList; } set { 
                _songList = value;
                //if (GlobalData.AudioPlayer.PlayListName!="Songs:All")
                //{
                //    GlobalData.AudioPlayer.SetPlayList("Songs:All", SongList.ToList());
                //}
                OnPropertyChanged(nameof(SongList)); } }

        public SongListViewModel()
        {
            SongList = new ObservableCollection<MusicInfo>();
            SongList = GlobalData.MusicLibrary.Musics;
        }

        public void SonglistView_ItemClick(object sender, ItemClickEventArgs e)
        {
            MusicInfo musicInfo = e.ClickedItem as MusicInfo;
            // 如果未进歌单，则进歌单
            if (GlobalData.AudioPlayer.PlayListName != "Songs:All")
            {
                GlobalData.AudioPlayer.SetPlayList("Songs:All", SongList.ToList());
            }
            GlobalData.AudioPlayer.UpdateShuffle();
            GlobalData.AudioPlayer.PlayListSongByPath(musicInfo.Path);

        }
    }
}
