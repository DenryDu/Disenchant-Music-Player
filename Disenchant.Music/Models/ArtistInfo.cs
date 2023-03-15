using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disenchant.Music.Models
{
    internal class ArtistInfo : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public ArtistInfo() { }
        public ArtistInfo(MusicInfo musicInfo, string name)
        {
            this.Name = name;
            this.Cover = musicInfo.Cover;
            this.TotalNum = 1;
        }
        public string GetTotalNum(int num)
        {
            if (num == 1)
                return 1 + " Song";
            else
                return num + " Songs";
        }
        //艺术家名
        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        //封面路径（当作头像，默认为检索到的第一张）
        private BitmapImage _cover;
        public BitmapImage Cover { get { return _cover; } set { _cover = value; OnPropertyChanged(nameof(Cover)); } }
        //歌曲数量
        private int _totalNum;
        public int TotalNum { get { return _totalNum; } set { _totalNum = value; OnPropertyChanged(nameof(TotalNum)); } }
    }
}
