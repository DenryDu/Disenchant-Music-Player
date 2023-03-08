using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.BulkAccess;

namespace DisenchantMusicPlayer.Model
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
        private HashSet<AlbumInfo> _albums;
        public HashSet<AlbumInfo> Albums { get { return _albums; } set { _albums = value; OnPropertyChanged(nameof(Albums)); } }

        private HashSet<ArtistInfo> _artists;
        public HashSet<ArtistInfo> Artists { get { return _artists; } set { _artists = value; OnPropertyChanged(nameof(Artists)); } }   

        private ObservableCollection<MusicInfo> _musics;
        public ObservableCollection<MusicInfo> Musics { get { return _musics; } set { _musics = value; OnPropertyChanged(nameof(Musics)); } }

        public async void InitMusics()
        {
            Musics = new ObservableCollection<MusicInfo>();
            // 从文件夹中读取
            if (Folder.Path!=null&&Folder.Path.Length>0)
            {
                IReadOnlyList<StorageFile> allFile = await Folder.GetFilesAsync();

                foreach (StorageFile fi in allFile)
                {
                    if ( GlobalData.SupportedAudioTypes.Contains(fi.FileType.ToLower()) ) 
                    {
                        Musics.Add(new MusicInfo(fi));
                    }
                }

            }
        }
        public MusicLibrary() 
        {
            Musics = new ObservableCollection<MusicInfo>();
            Artists = new HashSet<ArtistInfo>();
            Albums = new HashSet<AlbumInfo>();
        }
        /// <summary>
        /// 公开静态方法
        /// </summary>
        //刷新专辑set
        //刷新表演者set
    }
}
