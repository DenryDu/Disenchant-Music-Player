// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Disenchant.Music.Model;
using Disenchant.Music.ViewModel;
using Disenchant.Music.Views;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.VisualBasic.Devices;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using Windows.Devices.Radios;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static Disenchant.Music.Model.AudioPlayer;
using static System.Windows.Forms.DataFormats;
using Button = Microsoft.UI.Xaml.Controls.Button;
using WinRT;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Disenchant.Music
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
          
            // Set Title
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);

            RootNavFrame.Navigate(typeof(RootNavView));
            RootPlayBarFrame.Navigate(typeof(RootPlayBarView));

            mainViewModel = new MainViewModel();
            MainViewModel.MainWindow = this;
            GlobalData.MainWindow = this;
        }

        internal MainViewModel mainViewModel;
        public Frame GetRootNavFrame()
        {
            return RootNavFrame;
        }
    }
}
