// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Disenchant.Music.Models;
using Disenchant.Music.ViewModels;
using Microsoft.UI.Composition;
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
using System.Numerics;
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
    public sealed partial class AlbumListView : Page
    {
        private AlbumListViewModel _albumListViewModel = new AlbumListViewModel();
        public AlbumListView()
        {
            this.InitializeComponent();
        }

        private void AlbumsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            AlbumInfo albumInfo = e.ClickedItem as AlbumInfo;
            //((Microsoft.UI.Xaml.Controls.ContentControl)AlbumsGridView.ContainerFromIndex(1)).ContentTemplateRoot
            StackPanel stackPanel = (StackPanel)((ContentControl)AlbumsGridView.ContainerFromItem(e.ClickedItem)).ContentTemplateRoot;
            Border border = (Border)stackPanel.Children[0];
            
            GlobalData.SelectedAlbum = albumInfo.Name;
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("forwardAnimation", border);
            GlobalData.RootNavView.GetFrame().Navigate(typeof(AlbumDetailView), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            GlobalData.RootNavStatus = "albumdetail";
        }
        /*
        Compositor _compositor = GlobalData.CurrentWindow.Compositor;
        SpringVector3NaturalMotionAnimation _springAnimation;

        private void CreateOrUpdateSpringAnimation(float finalValue)
        {
            if (_springAnimation == null)
            {
                _springAnimation = _compositor.CreateSpringVector3Animation();
                _springAnimation.Target = "Scale";
            }

            _springAnimation.FinalValue = new Vector3(finalValue);
        }
        
        private void element_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            StackPanel stackPanel = (StackPanel)sender;
            stackPanel.Margin = new Thickness(10);
            stackPanel.Width = 220;
            Border border = (Border)stackPanel.Children[0];
            border.Width = 220;
            border.Height = 220;
            Image image = (Image)border.Child;
            image.Width = 220;
            image.Height = 220;
            // Scale up to 1.5
            //CreateOrUpdateSpringAnimation(1.05f);

            //(sender as UIElement).StartAnimation(_springAnimation);
        }

        private void element_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            // Scale back down to 1.0
            //CreateOrUpdateSpringAnimation(1.0f);

            //(sender as UIElement).StartAnimation(_springAnimation);

            StackPanel stackPanel = (StackPanel)sender;
            stackPanel.Margin = new Thickness(20);
            stackPanel.Width = 200;
            Border border = (Border)stackPanel.Children[0];
            border.Width = 200;
            border.Height = 200;
            Image image = (Image)border.Child;
            image.Width = 200;
            image.Height = 200;
        }
        */
    }
}
