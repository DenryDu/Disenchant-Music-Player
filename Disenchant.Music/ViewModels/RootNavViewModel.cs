using Disenchant.Music.Views;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disenchant.Music.ViewModels
{
    internal class RootNavViewModel
    {
        // List of ValueTuple holding the Navigation Tag and the relative Navigation Page
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("songlist", typeof(SongListView)),
            ("albumlist", typeof(AlbumListView)),
            ("artistlist", typeof(ArtistListView)),
            ("playlist", typeof(PlayListView)),
            ("settings", typeof(SettingsView)),
            ("albumdetail", typeof(AlbumDetailView)),
            ("artistdetail", typeof(ArtistDetailView)),
        };
        public RootNavViewModel()
        {
            if(GlobalData.RootNavStatus == null || GlobalData.RootNavStatus == "")
            {
                GlobalData.RootNavView.GetFrame().Navigate(typeof(SongListView));
            }
            else
            {
                GlobalData.RootNavView.GetFrame().Navigate(_pages.FirstOrDefault(x => x.Tag.Equals(GlobalData.RootNavStatus)).Page);
            }
        }
        // Navigation
        internal void NavView_ItemInvoked(NavigationView sender,
                                      NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
                GlobalData.RootNavStatus = "settings";
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
                GlobalData.RootNavStatus = navItemTag;
            }
        }
        internal void NavView_Navigate(
            string navItemTag,
            Microsoft.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")
            {
                _page = typeof(SettingsView);
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }
            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = GlobalData.RootNavView.GetFrame().CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                GlobalData.RootNavView.GetFrame().Navigate(_page, null, transitionInfo);
            }
        }
    }
}
