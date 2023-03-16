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
    public sealed partial class SongDetailView : Page
    {
        private SongListViewModel songListViewModel;
        public SongDetailView()
        {
            this.InitializeComponent();
            songListViewModel = new SongListViewModel();
            MAudioPlayer.songDetailUI = this;
        }
        public ScrollViewer GetLyricViewer()
        {
            return LyricViewer;
        }
        public ItemsControl GetLyricStackPanel()
        {
            return LyricStackPanel;
        }
        public TextBlock GetCurrentLyricItem(int CurrentIndex)
        {
            ListViewItem item = (ListViewItem)LyricStackPanel.Items[CurrentIndex];

            return LyricStackPanel.Items[CurrentIndex] as TextBlock;
        }

        private void TextBlock_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock tbItem = (TextBlock)sender;
            if (tbItem.FontSize == 50 || tbItem.FontSize == 24)
            {
                var currentScrollPosition = LyricViewer.VerticalOffset;
                var point = new Point(0, currentScrollPosition);

                // 计算出目标位置并滚动
                var targetPosition = tbItem.TransformToVisual(LyricViewer).TransformPoint(point);
                if(tbItem.FontSize == 24)
                {
                    LyricViewer.ScrollToVerticalOffset(targetPosition.Y);
                }
                else
                {
                    LyricViewer.ScrollToVerticalOffset(targetPosition.Y - LyricViewer.Height / 2 + 40);
                }

            }
        }
    }
}
