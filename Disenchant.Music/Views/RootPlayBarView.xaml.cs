// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Disenchant.Music.Model;
using Disenchant.Music.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Disenchant.Music.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RootPlayBarView : Page
    {
        public RootPlayBarView()
        {
            this.InitializeComponent();
            // 绑定ViewModel
            RootPlayBarViewModel.RootPlayBarView = this;
            RootPlayBarViewModel = new RootPlayBarViewModel();
            // 绑定播放器
            AudioPlayer.PlayBarUI = this;

            // 往SongListPage外送一个对象
            SongListViewModel.RootPlayBarView = this;
        }
        public Slider GetProgressSlider()
        {
            return this.ProgressSlider;
        }
        private RootPlayBarViewModel _rootPlayBarViewModel;
        internal RootPlayBarViewModel RootPlayBarViewModel;

        private void VolumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }
    }
}
