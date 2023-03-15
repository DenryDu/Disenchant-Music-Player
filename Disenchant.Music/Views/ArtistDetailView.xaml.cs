// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Disenchant.Music.ViewModels;
using Microsoft.UI.Xaml.Media.Animation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Disenchant.Music.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArtistDetailView : Page
    {
        private ArtistDetailViewModel _artistDetailViewModel = new ArtistDetailViewModel();
        public ArtistDetailView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _artistDetailViewModel.Init(GlobalData.SelectedArtist);

            ConnectedAnimation animation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("ArtistToDetailAnimation");
            if (animation != null)
            {
                animation.TryStart(ArtistCover);
            }
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.RootNavView.GetFrame().Navigate(typeof(ArtistListView), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
            GlobalData.RootNavStatus = "artistlist";
        }
    }
}
