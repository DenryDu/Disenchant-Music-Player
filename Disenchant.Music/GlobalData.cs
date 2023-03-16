using Disenchant.Music.Helpers;
using Disenchant.Music.Model;
using Disenchant.Music.Models;
using Disenchant.Music.Views;
using Microsoft.UI.Windowing;
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

        // Play Btn
        public static readonly string[] PlayPauseIcon = {
            StringHelper.UnicodeToStr("&#xe768;"),
            StringHelper.UnicodeToStr("&#xe769;")
        };

        // PlayMode Btn
        public static readonly string[] PlayModeIcon = { 
            StringHelper.UnicodeToStr("&#xE14B;"),
            StringHelper.UnicodeToStr("&#xE1CD;"),
            StringHelper.UnicodeToStr("&#xE1CC;")
        };


        ///
        /// Variable
        ///
        private static MusicLibrary _musicLibrary;
        internal static MusicLibrary MusicLibrary { get; set; } = new MusicLibrary();


        private static MAudioPlayer _audioPlayer;
        internal static MAudioPlayer AudioPlayer { get; set; } = new MAudioPlayer();

        public static Window CurrentWindow;

        public static MainWindow MainWindow;

        public static bool IsDetail = false;

        public static string RootNavStatus;

        internal static string SelectedAlbum;
        internal static string SelectedArtist;

        public static RootNavView RootNavView;

        public static AppWindow AppWindow;
    }
}
