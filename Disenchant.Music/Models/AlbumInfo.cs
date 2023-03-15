using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disenchant.Music.Models
{
    internal class AlbumInfo : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public AlbumInfo() { }
        public AlbumInfo(MusicInfo musicInfo)
        {
            this.Name = musicInfo.Album;
            this.Year = musicInfo.Year;
            this.Cover = musicInfo.Cover;
            Cover.DecodePixelHeight = 200; Cover.DecodePixelWidth = 200;
            this.Artist = musicInfo.GetArtists();
            this.TotalDuration = musicInfo.Duration;
            this.TotalNum = 1;
        }
        public void Update(MusicInfo musicInfo)
        {
            this.TotalNum++;
            this.TotalDuration += musicInfo.Duration;
        }
        public string GetCountAndYearStr(int num, uint year)
        {
            string str = "";
            if (num > 1)
                str += num + " songs";
            else
                str += num + " song";
            if (year == 0)
                str += " 未知年份";
            else
                str += " " + year;
            return str;
        }
        //专辑名
        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        //专辑封面路径
        private BitmapImage _cover;
        public BitmapImage Cover { get { return _cover; } set { _cover = value; OnPropertyChanged(nameof(Cover)); } }

        private string _artist;
        public string Artist { get { return _artist; } set { _artist = value; OnPropertyChanged(nameof(Artist)); } }

        //专辑包含的歌曲数量
        private int _totalNum;
        public int TotalNum { get { return _totalNum; } set { _totalNum = value; OnPropertyChanged(nameof(TotalNum)); } }

        private TimeSpan _totalDuration;
        public TimeSpan TotalDuration { get { return _totalDuration; } set { _totalDuration = value; OnPropertyChanged(nameof(TotalDuration)); } }  

        //专辑发布年份
        private uint _year;
        public uint Year { get { return _year; } set { _year = value; OnPropertyChanged(nameof(Year)); } }
    }
}
