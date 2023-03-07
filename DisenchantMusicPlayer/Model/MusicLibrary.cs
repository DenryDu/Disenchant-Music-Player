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
        public static HashSet<AlbumInfo> albums;

        //维护一个表演者Set
        public static HashSet<ArtistInfo> artists;

        public static ObservableCollection<MusicInfo> musics;

        public async void InitMusics()
        {
            musics = new ObservableCollection<MusicInfo>();
            // 从文件夹中读取
            if (Folder.Path!=null&&Folder.Path.Length>0)
            {
                IReadOnlyList<StorageFile> allFile = await Folder.GetFilesAsync();

                foreach (StorageFile fi in allFile)
                {
                    if (fi.FileType.ToLower().Contains(".mp3") || fi.FileType.ToLower().Contains(".flac") || fi.FileType.ToLower().Contains(".wav") ) 
                    {
                        musics.Add(new MusicInfo(fi));
                    }
                }

            }
            Debug.WriteLine(musics.ToString());
        }

        /// <summary>
        /// 公开静态方法
        /// </summary>
        //刷新专辑set
        //刷新表演者set
    }
}
