// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Disenchant.Music.Models;
using Disenchant.Music.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
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
    public sealed partial class ArtistListView : Page
    {
        private ArtistListViewModel _artistListViewModel = new ArtistListViewModel();
        public ArtistListView()
        {
            this.InitializeComponent();
        }

        public void ArtistsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ArtistInfo artistInfo = e.ClickedItem as ArtistInfo;
            //((Microsoft.UI.Xaml.Controls.ContentControl)AlbumsGridView.ContainerFromIndex(1)).ContentTemplateRoot
            StackPanel stackPanel = (StackPanel)((ContentControl)ArtistsGridView.ContainerFromItem(e.ClickedItem)).ContentTemplateRoot;
            Border border = (Border)stackPanel.Children[0];

            GlobalData.SelectedArtist = artistInfo.Name;
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ArtistToDetailAnimation", border);
            GlobalData.RootNavView.GetFrame().Navigate(typeof(ArtistDetailView), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            GlobalData.RootNavStatus = "artistdetail";
        }
    }
}
