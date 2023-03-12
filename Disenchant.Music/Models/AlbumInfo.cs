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

        //专辑名
        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        //专辑封面路径
        private string _cover;
        public string Cover { get { return _cover; } set { _cover = value; OnPropertyChanged(nameof(Cover)); } }
        //专辑包含的歌曲数量
        private int _totalNum;
        public int TotalNum { get { return _totalNum; } set { _totalNum = value; OnPropertyChanged(nameof(TotalNum)); } }
        //专辑发布年份
        private string _year;
        public string Year { get { return _year; } set { _year = value; OnPropertyChanged(nameof(Year)); } }
    }
}
