using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TagLib;

namespace DisenchantMusicPlayer.Model
{
    internal class MusicInfo : INotifyPropertyChanged
    {
        /// <summary>
        /// 公开静态资源
        /// </summary>
        //所有音乐的根目录
        public static string folderPath = "./Assets/";

        //维护一个专辑-CoverSet
        public static List<AlbumInfo> albums;

        //维护一个表演者Set

        /// <summary>
        /// 公开静态方法
        /// </summary>
        //刷新专辑set
        //刷新表演者set

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        // 构造函数
        public MusicInfo(string path)
        {
            Path = folderPath + path;
            TagLib.File f = TagLib.File.Create(Path);
            Album = f.Tag.Album;
            Artists = f.Tag.AlbumArtists.Concat(f.Tag.Performers).ToArray();
            Title = f.Tag.Title;

        }

        /// <summary>
        /// 私有属性
        /// </summary>

        // 歌曲文件名（路径）
        private string _path;
        public string Path { get { return _path; } set { _path = value; OnPropertyChanged(nameof(Path)); } }

        // 专辑名
        private string _album;
        public string Album { get { return _album; } set { _album = value; OnPropertyChanged(nameof(_album)); } }

        // 歌名
        private string _title;
        public string Title { get { return _title; } set { _title = value; OnPropertyChanged(nameof(_title)); } }

        // 艺术家
        // albumArtists;
        // performers;
        private string[] _artists;
        public string[] Artists { 
            get { return _artists; } 
            set {
                if ( value.Length > 0)
                {
                    string[] tempArtists = new string[0];
                    foreach (string i in value)
                    {
                        if (i.Contains("、"))
                        {
                            tempArtists = tempArtists.Concat(i.Split('、')).ToArray();
                        }
                        else if (i.Contains(","))
                        {
                            tempArtists = tempArtists.Concat(i.Split(',')).ToArray();
                        }
                        else if (i.Contains("，"))
                        {
                            tempArtists = tempArtists.Concat(i.Split('，')).ToArray();
                        }
                        else
                        {
                            tempArtists = tempArtists.Concat(i.Split("")).ToArray();
                        }
                    }
                    _artists = tempArtists.Distinct().ToArray();
                }
                else
                {
                    _artists = new string[0];
                }
                
                OnPropertyChanged(nameof(Artists)); 
            } 
        }

    }
}

