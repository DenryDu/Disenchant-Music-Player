// WARNING: Please don't edit this file. It was generated by C++/WinRT v2.0.220929.3

#pragma once
#ifndef WINRT_DisenchantMusicPlayer_2_H
#define WINRT_DisenchantMusicPlayer_2_H
#include "winrt/impl/Microsoft.UI.Composition.1.h"
#include "winrt/impl/Microsoft.UI.Xaml.1.h"
#include "winrt/impl/Microsoft.UI.Xaml.Controls.1.h"
#include "winrt/impl/Microsoft.UI.Xaml.Markup.1.h"
#include "winrt/impl/Windows.UI.Xaml.Data.1.h"
#include "winrt/impl/DisenchantMusicPlayer.1.h"
WINRT_EXPORT namespace winrt::DisenchantMusicPlayer
{
    struct __declspec(empty_bases) AlbumlistPage : winrt::DisenchantMusicPlayer::IAlbumlistPage,
        impl::base<AlbumlistPage, winrt::Microsoft::UI::Xaml::Controls::Page, winrt::Microsoft::UI::Xaml::Controls::UserControl, winrt::Microsoft::UI::Xaml::Controls::Control, winrt::Microsoft::UI::Xaml::FrameworkElement, winrt::Microsoft::UI::Xaml::UIElement, winrt::Microsoft::UI::Xaml::DependencyObject>,
        impl::require<AlbumlistPage, winrt::Microsoft::UI::Xaml::Controls::IPage, winrt::Microsoft::UI::Xaml::Controls::IPageOverrides, winrt::Microsoft::UI::Xaml::Controls::IUserControl, winrt::Microsoft::UI::Xaml::Controls::IControl, winrt::Microsoft::UI::Xaml::Controls::IControlProtected, winrt::Microsoft::UI::Xaml::Controls::IControlOverrides, winrt::Microsoft::UI::Xaml::IFrameworkElement, winrt::Microsoft::UI::Xaml::IFrameworkElementProtected, winrt::Microsoft::UI::Xaml::IFrameworkElementOverrides, winrt::Microsoft::UI::Xaml::IUIElement, winrt::Microsoft::UI::Xaml::IUIElementProtected, winrt::Microsoft::UI::Xaml::IUIElementOverrides, winrt::Microsoft::UI::Composition::IAnimationObject, winrt::Microsoft::UI::Composition::IVisualElement, winrt::Microsoft::UI::Composition::IVisualElement2, winrt::Microsoft::UI::Xaml::IDependencyObject>
    {
        AlbumlistPage(std::nullptr_t) noexcept {}
        AlbumlistPage(void* ptr, take_ownership_from_abi_t) noexcept : winrt::DisenchantMusicPlayer::IAlbumlistPage(ptr, take_ownership_from_abi) {}
        AlbumlistPage();
    };
    struct __declspec(empty_bases) ArtistlistPage : winrt::DisenchantMusicPlayer::IArtistlistPage,
        impl::base<ArtistlistPage, winrt::Microsoft::UI::Xaml::Controls::Page, winrt::Microsoft::UI::Xaml::Controls::UserControl, winrt::Microsoft::UI::Xaml::Controls::Control, winrt::Microsoft::UI::Xaml::FrameworkElement, winrt::Microsoft::UI::Xaml::UIElement, winrt::Microsoft::UI::Xaml::DependencyObject>,
        impl::require<ArtistlistPage, winrt::Microsoft::UI::Xaml::Controls::IPage, winrt::Microsoft::UI::Xaml::Controls::IPageOverrides, winrt::Microsoft::UI::Xaml::Controls::IUserControl, winrt::Microsoft::UI::Xaml::Controls::IControl, winrt::Microsoft::UI::Xaml::Controls::IControlProtected, winrt::Microsoft::UI::Xaml::Controls::IControlOverrides, winrt::Microsoft::UI::Xaml::IFrameworkElement, winrt::Microsoft::UI::Xaml::IFrameworkElementProtected, winrt::Microsoft::UI::Xaml::IFrameworkElementOverrides, winrt::Microsoft::UI::Xaml::IUIElement, winrt::Microsoft::UI::Xaml::IUIElementProtected, winrt::Microsoft::UI::Xaml::IUIElementOverrides, winrt::Microsoft::UI::Composition::IAnimationObject, winrt::Microsoft::UI::Composition::IVisualElement, winrt::Microsoft::UI::Composition::IVisualElement2, winrt::Microsoft::UI::Xaml::IDependencyObject>
    {
        ArtistlistPage(std::nullptr_t) noexcept {}
        ArtistlistPage(void* ptr, take_ownership_from_abi_t) noexcept : winrt::DisenchantMusicPlayer::IArtistlistPage(ptr, take_ownership_from_abi) {}
        ArtistlistPage();
    };
    struct __declspec(empty_bases) MainWindow : winrt::DisenchantMusicPlayer::IMainWindow,
        impl::base<MainWindow, winrt::Microsoft::UI::Xaml::Window>,
        impl::require<MainWindow, winrt::Microsoft::UI::Xaml::IWindow>
    {
        MainWindow(std::nullptr_t) noexcept {}
        MainWindow(void* ptr, take_ownership_from_abi_t) noexcept : winrt::DisenchantMusicPlayer::IMainWindow(ptr, take_ownership_from_abi) {}
        MainWindow();
    };
    struct __declspec(empty_bases) PlaylistsPage : winrt::DisenchantMusicPlayer::IPlaylistsPage,
        impl::base<PlaylistsPage, winrt::Microsoft::UI::Xaml::Controls::Page, winrt::Microsoft::UI::Xaml::Controls::UserControl, winrt::Microsoft::UI::Xaml::Controls::Control, winrt::Microsoft::UI::Xaml::FrameworkElement, winrt::Microsoft::UI::Xaml::UIElement, winrt::Microsoft::UI::Xaml::DependencyObject>,
        impl::require<PlaylistsPage, winrt::Microsoft::UI::Xaml::Controls::IPage, winrt::Microsoft::UI::Xaml::Controls::IPageOverrides, winrt::Microsoft::UI::Xaml::Controls::IUserControl, winrt::Microsoft::UI::Xaml::Controls::IControl, winrt::Microsoft::UI::Xaml::Controls::IControlProtected, winrt::Microsoft::UI::Xaml::Controls::IControlOverrides, winrt::Microsoft::UI::Xaml::IFrameworkElement, winrt::Microsoft::UI::Xaml::IFrameworkElementProtected, winrt::Microsoft::UI::Xaml::IFrameworkElementOverrides, winrt::Microsoft::UI::Xaml::IUIElement, winrt::Microsoft::UI::Xaml::IUIElementProtected, winrt::Microsoft::UI::Xaml::IUIElementOverrides, winrt::Microsoft::UI::Composition::IAnimationObject, winrt::Microsoft::UI::Composition::IVisualElement, winrt::Microsoft::UI::Composition::IVisualElement2, winrt::Microsoft::UI::Xaml::IDependencyObject>
    {
        PlaylistsPage(std::nullptr_t) noexcept {}
        PlaylistsPage(void* ptr, take_ownership_from_abi_t) noexcept : winrt::DisenchantMusicPlayer::IPlaylistsPage(ptr, take_ownership_from_abi) {}
        PlaylistsPage();
    };
    struct __declspec(empty_bases) SettingsPage : winrt::DisenchantMusicPlayer::ISettingsPage,
        impl::base<SettingsPage, winrt::Microsoft::UI::Xaml::Controls::Page, winrt::Microsoft::UI::Xaml::Controls::UserControl, winrt::Microsoft::UI::Xaml::Controls::Control, winrt::Microsoft::UI::Xaml::FrameworkElement, winrt::Microsoft::UI::Xaml::UIElement, winrt::Microsoft::UI::Xaml::DependencyObject>,
        impl::require<SettingsPage, winrt::Microsoft::UI::Xaml::Controls::IPage, winrt::Microsoft::UI::Xaml::Controls::IPageOverrides, winrt::Microsoft::UI::Xaml::Controls::IUserControl, winrt::Microsoft::UI::Xaml::Controls::IControl, winrt::Microsoft::UI::Xaml::Controls::IControlProtected, winrt::Microsoft::UI::Xaml::Controls::IControlOverrides, winrt::Microsoft::UI::Xaml::IFrameworkElement, winrt::Microsoft::UI::Xaml::IFrameworkElementProtected, winrt::Microsoft::UI::Xaml::IFrameworkElementOverrides, winrt::Microsoft::UI::Xaml::IUIElement, winrt::Microsoft::UI::Xaml::IUIElementProtected, winrt::Microsoft::UI::Xaml::IUIElementOverrides, winrt::Microsoft::UI::Composition::IAnimationObject, winrt::Microsoft::UI::Composition::IVisualElement, winrt::Microsoft::UI::Composition::IVisualElement2, winrt::Microsoft::UI::Xaml::IDependencyObject>
    {
        SettingsPage(std::nullptr_t) noexcept {}
        SettingsPage(void* ptr, take_ownership_from_abi_t) noexcept : winrt::DisenchantMusicPlayer::ISettingsPage(ptr, take_ownership_from_abi) {}
        SettingsPage();
    };
    struct __declspec(empty_bases) SonglistItem : winrt::DisenchantMusicPlayer::ISonglistItem,
        impl::require<SonglistItem, winrt::Windows::UI::Xaml::Data::INotifyPropertyChanged>
    {
        SonglistItem(std::nullptr_t) noexcept {}
        SonglistItem(void* ptr, take_ownership_from_abi_t) noexcept : winrt::DisenchantMusicPlayer::ISonglistItem(ptr, take_ownership_from_abi) {}
        SonglistItem(param::hstring const& songName, param::hstring const& albumName, param::hstring const& coverPath);
    };
    struct __declspec(empty_bases) SonglistPage : winrt::DisenchantMusicPlayer::ISonglistPage,
        impl::base<SonglistPage, winrt::Microsoft::UI::Xaml::Controls::Page, winrt::Microsoft::UI::Xaml::Controls::UserControl, winrt::Microsoft::UI::Xaml::Controls::Control, winrt::Microsoft::UI::Xaml::FrameworkElement, winrt::Microsoft::UI::Xaml::UIElement, winrt::Microsoft::UI::Xaml::DependencyObject>,
        impl::require<SonglistPage, winrt::Microsoft::UI::Xaml::Controls::IPage, winrt::Microsoft::UI::Xaml::Controls::IPageOverrides, winrt::Microsoft::UI::Xaml::Controls::IUserControl, winrt::Microsoft::UI::Xaml::Controls::IControl, winrt::Microsoft::UI::Xaml::Controls::IControlProtected, winrt::Microsoft::UI::Xaml::Controls::IControlOverrides, winrt::Microsoft::UI::Xaml::IFrameworkElement, winrt::Microsoft::UI::Xaml::IFrameworkElementProtected, winrt::Microsoft::UI::Xaml::IFrameworkElementOverrides, winrt::Microsoft::UI::Xaml::IUIElement, winrt::Microsoft::UI::Xaml::IUIElementProtected, winrt::Microsoft::UI::Xaml::IUIElementOverrides, winrt::Microsoft::UI::Composition::IAnimationObject, winrt::Microsoft::UI::Composition::IVisualElement, winrt::Microsoft::UI::Composition::IVisualElement2, winrt::Microsoft::UI::Xaml::IDependencyObject>
    {
        SonglistPage(std::nullptr_t) noexcept {}
        SonglistPage(void* ptr, take_ownership_from_abi_t) noexcept : winrt::DisenchantMusicPlayer::ISonglistPage(ptr, take_ownership_from_abi) {}
        SonglistPage();
    };
    struct __declspec(empty_bases) StatisticPage : winrt::DisenchantMusicPlayer::IStatisticPage,
        impl::base<StatisticPage, winrt::Microsoft::UI::Xaml::Controls::Page, winrt::Microsoft::UI::Xaml::Controls::UserControl, winrt::Microsoft::UI::Xaml::Controls::Control, winrt::Microsoft::UI::Xaml::FrameworkElement, winrt::Microsoft::UI::Xaml::UIElement, winrt::Microsoft::UI::Xaml::DependencyObject>,
        impl::require<StatisticPage, winrt::Microsoft::UI::Xaml::Controls::IPage, winrt::Microsoft::UI::Xaml::Controls::IPageOverrides, winrt::Microsoft::UI::Xaml::Controls::IUserControl, winrt::Microsoft::UI::Xaml::Controls::IControl, winrt::Microsoft::UI::Xaml::Controls::IControlProtected, winrt::Microsoft::UI::Xaml::Controls::IControlOverrides, winrt::Microsoft::UI::Xaml::IFrameworkElement, winrt::Microsoft::UI::Xaml::IFrameworkElementProtected, winrt::Microsoft::UI::Xaml::IFrameworkElementOverrides, winrt::Microsoft::UI::Xaml::IUIElement, winrt::Microsoft::UI::Xaml::IUIElementProtected, winrt::Microsoft::UI::Xaml::IUIElementOverrides, winrt::Microsoft::UI::Composition::IAnimationObject, winrt::Microsoft::UI::Composition::IVisualElement, winrt::Microsoft::UI::Composition::IVisualElement2, winrt::Microsoft::UI::Xaml::IDependencyObject>
    {
        StatisticPage(std::nullptr_t) noexcept {}
        StatisticPage(void* ptr, take_ownership_from_abi_t) noexcept : winrt::DisenchantMusicPlayer::IStatisticPage(ptr, take_ownership_from_abi) {}
        StatisticPage();
    };
    struct __declspec(empty_bases) XamlMetaDataProvider : winrt::Microsoft::UI::Xaml::Markup::IXamlMetadataProvider
    {
        XamlMetaDataProvider(std::nullptr_t) noexcept {}
        XamlMetaDataProvider(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::UI::Xaml::Markup::IXamlMetadataProvider(ptr, take_ownership_from_abi) {}
        XamlMetaDataProvider();
    };
}
#endif
