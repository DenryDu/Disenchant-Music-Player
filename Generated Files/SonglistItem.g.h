// WARNING: Please don't edit this file. It was generated by C++/WinRT v2.0.220929.3

#pragma once
#include "winrt/DisenchantMusicPlayer.h"
#include "winrt/Windows.UI.Xaml.Data.h"
namespace winrt::DisenchantMusicPlayer::implementation
{
    template <typename D, typename... I>
    struct __declspec(empty_bases) SonglistItem_base : implements<D, DisenchantMusicPlayer::SonglistItem, winrt::Windows::UI::Xaml::Data::INotifyPropertyChanged, I...>
    {
        using base_type = SonglistItem_base;
        using class_type = DisenchantMusicPlayer::SonglistItem;
        using implements_type = typename SonglistItem_base::implements_type;
        using implements_type::implements_type;
        
        hstring GetRuntimeClassName() const
        {
            return L"DisenchantMusicPlayer.SonglistItem";
        }
    };
}
namespace winrt::DisenchantMusicPlayer::factory_implementation
{
    template <typename D, typename T, typename... I>
    struct __declspec(empty_bases) SonglistItemT : implements<D, winrt::Windows::Foundation::IActivationFactory, winrt::DisenchantMusicPlayer::ISonglistItemFactory, I...>
    {
        using instance_type = DisenchantMusicPlayer::SonglistItem;

        hstring GetRuntimeClassName() const
        {
            return L"DisenchantMusicPlayer.SonglistItem";
        }
        auto CreateInstance(hstring const& songName, hstring const& albumName, hstring const& coverPath)
        {
            return make<T>(songName, albumName, coverPath);
        }
        [[noreturn]] winrt::Windows::Foundation::IInspectable ActivateInstance() const
        {
            throw hresult_not_implemented();
        }
    };
}

#if defined(WINRT_FORCE_INCLUDE_SONGLISTITEM_XAML_G_H) || __has_include("SonglistItem.xaml.g.h")

#include "SonglistItem.xaml.g.h"

#else

namespace winrt::DisenchantMusicPlayer::implementation
{
    template <typename D, typename... I>
    using SonglistItemT = SonglistItem_base<D, I...>;
}

#endif
