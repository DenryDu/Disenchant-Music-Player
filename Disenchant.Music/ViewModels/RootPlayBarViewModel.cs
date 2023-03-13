using Disenchant.Music.Model;
using Disenchant.Music.Models;
using Disenchant.Music.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Disenchant.Music.ViewModels
{
    internal class RootPlayBarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


        public RootPlayBarViewModel()
        {
            RootPlayBarView.GetProgressSlider().AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(GlobalData.AudioPlayer.ProgressLock), true);
            RootPlayBarView.GetProgressSlider().AddHandler(UIElement.PointerReleasedEvent, new PointerEventHandler(GlobalData.AudioPlayer.ProgressUpdate), true);
        }

        public static RootPlayBarView RootPlayBarView;
    }
}
