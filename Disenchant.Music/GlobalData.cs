using Disenchant.Music.Helpers;
using Disenchant.Music.Model;
using Disenchant.Music.Models;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disenchant.Music
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

        public static readonly string PlayBtnIcon = StringHelper.UnicodeToStr("&#xe768;");
        public static readonly string PauseBtnIcon = StringHelper.UnicodeToStr("&#xe769;");


        ///
        /// Variable
        ///
        private static MusicLibrary _musicLibrary;
        internal static MusicLibrary MusicLibrary { get; set; } = new MusicLibrary();


        private static AudioPlayer _audioPlayer;
        internal static AudioPlayer AudioPlayer { get; set; } = new AudioPlayer();

        public static Window CurrentWindow;
    }
}
