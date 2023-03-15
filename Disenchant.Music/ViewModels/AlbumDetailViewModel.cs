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
    class AlbumDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private AlbumInfo _albumInfo;
        public AlbumInfo AlbumInfo { get { return _albumInfo; } set { _albumInfo = value; OnPropertyChanged(nameof(AlbumInfo)); } }

        private ObservableCollection<MusicBriefInfo> _musicBriefs;
        public ObservableCollection<MusicBriefInfo> MusicBriefs { get { return _musicBriefs; } set { _musicBriefs = value; OnPropertyChanged(nameof(MusicBriefs)); } }

        public AlbumDetailViewModel()
        {
            MusicBriefs = new ObservableCollection<MusicBriefInfo>();
            AlbumInfo = new AlbumInfo();
        }
        public void Init(string name)
        {
            AlbumInfo = GlobalData.MusicLibrary.Albums[name];
            MusicBriefs = new ObservableCollection<MusicBriefInfo>(GlobalData.MusicLibrary.GetMusicBriefByAlbum(name));
        }
        public void Songlist_ItemClick(object sender, ItemClickEventArgs e)
        {
            MusicBriefInfo musicBriefInfo = e.ClickedItem as MusicBriefInfo;
            
            // 如果未进歌单，则进歌单
            if (GlobalData.AudioPlayer.PlayListName!="Album:"+AlbumInfo.Name)
            {
                GlobalData.AudioPlayer.SetPlayList(("Album:" + AlbumInfo.Name), MusicBriefs.ToList());
            }
            GlobalData.AudioPlayer.UpdateShuffle();
            GlobalData.AudioPlayer.PlayListSongByPath(musicBriefInfo.Path);
        }

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
    }
}
