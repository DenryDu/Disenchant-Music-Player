using DisenchantMusicPlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DisenchantMusicPlayer
{
    public static class GlobalData
    {
        /// <summary>
        /// Const
        /// </summary>

        // Token to access Music Foler
        public const string MusicLibraryFolderToken = "MusicLibraryFolderToken";

        // FileTypes supported by this proj
        public static readonly string[] SupportedAudioTypes = { ".flac", ".wav", ".m4a", ".aac", ".mp3", ".wma", ".ogg", ".oga", ".opus" };



        ///
        /// Variable
        ///
        private static MusicLibrary _musicLibrary;
        internal static MusicLibrary MusicLibrary { get; set; } = new MusicLibrary();

        private static MusicInfo _currentMusic;
        internal static MusicInfo CurrentMusic { get; set; } = new MusicInfo();
    }
}
