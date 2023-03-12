using Disenchant.Music.Model;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Disenchant.Music.Model.AudioPlayer;
using Disenchant.Music;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace Disenchant.Music.ViewModel
{
    internal class MainViewModel
    {
        public static MainWindow MainWindow;
  
        public MainViewModel() {
            AudioPlayer.SetSource(@"C:\Users\DenryDu\OneDrive\音频\Music\97  100  - 阿鲲 - 流浪地球2 电影原声大碟.flac");

  

        }

        internal AudioPlayer AudioPlayer = new AudioPlayer();
        //private RoutedEvent PointerPressedEvent; 
        //private RoutedEvent PointerReleasedEvent;
    



    }
}
