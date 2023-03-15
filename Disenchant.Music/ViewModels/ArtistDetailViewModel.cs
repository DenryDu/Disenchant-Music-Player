using Disenchant.Music.Models;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disenchant.Music.ViewModels
{
    class ArtistDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private ArtistInfo _artistInfo;
        public ArtistInfo ArtistInfo { get { return _artistInfo; } set { _artistInfo = value; OnPropertyChanged(nameof(ArtistInfo)); } }

        private ObservableCollection<MusicInfo> _musicInfos;
        public ObservableCollection<MusicInfo> MusicInfos { get { return _musicInfos; } set { _musicInfos = value; OnPropertyChanged(nameof(MusicInfos)); } }

        public ArtistDetailViewModel()
        {
            MusicInfos = new ObservableCollection<MusicInfo>();
            ArtistInfo = new ArtistInfo();
        }
        public void Init(string name)
        {
            ArtistInfo = GlobalData.MusicLibrary.Artists[name];
            MusicInfos = new ObservableCollection<MusicInfo>(GlobalData.MusicLibrary.GetMusicsByArtist(name));
        }
        public void Songlist_ItemClick(object sender, ItemClickEventArgs e)
        {
            MusicInfo musicInfo = e.ClickedItem as MusicInfo;

            // 如果未进歌单，则进歌单
            if (GlobalData.AudioPlayer.PlayListName != "Artist:" + ArtistInfo.Name)
            {
                GlobalData.AudioPlayer.SetPlayList(("Artist:" + ArtistInfo.Name), MusicInfos.ToList());
            }
            GlobalData.AudioPlayer.UpdateShuffle();
            GlobalData.AudioPlayer.PlayListSongByPath(musicInfo.Path);
        }

        /*
        public string TimeSpanConverter(TimeSpan value)
        {
            string temp = value.ToString().Split('.')[0];
            if (temp.Substring(1, 1) == "0")
                return temp.Substring(3, 5);
            else
                return temp;
        }
        public string YearConverter(uint year)
        {
            if (year == 0)
            {
                return "-";
            }
            else
            {
                return year.ToString();
            }
        }
        */
    }
}
