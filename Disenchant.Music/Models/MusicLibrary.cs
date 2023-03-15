using Disenchant.Music.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Disenchant.Music.Models
{
    internal class MusicLibrary : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// 公开静态资源
        /// </summary>
        //所有音乐的根目录
        private StorageFolder _folder;
        public StorageFolder Folder { get { return _folder; } set { _folder = value; OnPropertyChanged(nameof(Folder)); } }

        //维护一个专辑-CoverSet
        private Dictionary<string, AlbumInfo> _albums;
        public Dictionary<string, AlbumInfo> Albums { get { return _albums; } set { _albums = value; OnPropertyChanged(nameof(Albums)); } }

        private Dictionary<string, ArtistInfo> _artists;
        public Dictionary<string, ArtistInfo> Artists { get { return _artists; } set { _artists = value; OnPropertyChanged(nameof(Artists)); } }

        private ObservableCollection<MusicInfo> _musics;
        public ObservableCollection<MusicInfo> Musics { get { return _musics; } set { _musics = value; OnPropertyChanged(nameof(Musics)); } }

        // 资源字典：文件名-文件快速索引
        private Dictionary<string, StorageFile> _dictionary;
        public Dictionary<string, StorageFile> Dictionary { get { return _dictionary; } set { _dictionary = value; OnPropertyChanged(nameof(Dictionary)); } }

        public async void InitMusics()
        {
            Musics = new ObservableCollection<MusicInfo>();
            Dictionary = new Dictionary<string, StorageFile>();
            // 从文件夹中读取
            if (Folder.Path != null && Folder.Path.Length > 0)
            {
                IReadOnlyList<StorageFile> allFile = await Folder.GetFilesAsync();

                foreach (StorageFile fi in allFile)
                {
                    if (GlobalData.SupportedAudioTypes.Contains(fi.FileType.ToLower()))
                    {
                        MusicInfo music = new MusicInfo(fi.Path);
                        Musics.Add(music);
                        if (!Albums.ContainsKey(music.Album))
                        {
                            Albums[music.Album] = new AlbumInfo(music);
                        }
                        else
                        {
                            Albums[music.Album].Update(music);
                        }

                        foreach(string artist in music.Artists)
                        {
                            if (!Artists.ContainsKey(artist))
                            {
                                Artists[artist] = new ArtistInfo(music, artist);
                            }
                            else
                            {
                                Artists[artist].TotalNum++;
                            }
                        }
                        //Dictionary.Add(fi.Path, fi);
                    }
                }
            }
        }
        /*
        public StorageFile GetMusicFile(string path)
        {
            try
            {
                return Dictionary[path];
            }
            catch
            {
                return null;
            }
        }
        */

        public List<MusicBriefInfo> GetMusicBriefByAlbum(string name)
        {
            List<MusicBriefInfo> list = new List<MusicBriefInfo>();
            foreach(MusicInfo music in Musics)
            {
                if(music.Album == name)
                {
                    list.Add(new MusicBriefInfo(music.Path, music.Title));
                }
            }
            return list;
        }

        public List<MusicInfo> GetMusicsByArtist(string name)
        {
            List<MusicInfo> list = new List<MusicInfo>();
            foreach (MusicInfo music in Musics)
            {
                foreach(string artist in music.Artists)
                {
                    if(artist == name)
                    {
                        list.Add(music);
                    }
                }
            }
            return list;
        }
        
        public MusicLibrary()
        {
            Musics = new ObservableCollection<MusicInfo>();
            Artists = new Dictionary<string, ArtistInfo>();
            Albums = new Dictionary<string, AlbumInfo>();
        }
        /// <summary>
        /// 公开静态方法
        /// </summary>
        //刷新专辑set
        //刷新表演者set
    }
}
