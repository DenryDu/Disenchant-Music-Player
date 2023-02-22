// WARNING: Please don't edit this file. It was generated by C++/WinRT v2.0.220929.3

#pragma once
#include "winrt/DisenchantMusicPlayer.h"
#include "winrt/Microsoft.UI.Composition.h"
#include "winrt/Microsoft.UI.Xaml.h"
#include "winrt/Microsoft.UI.Xaml.Controls.h"
namespace winrt::DisenchantMusicPlayer::implementation
{
    template <typename D, typename... I>
    struct __declspec(empty_bases) PlaylistsPage_base : implements<D, DisenchantMusicPlayer::PlaylistsPage, composing, winrt::Microsoft::UI::Xaml::Controls::IPageOverrides, winrt::Microsoft::UI::Xaml::Controls::IControlOverrides, winrt::Microsoft::UI::Xaml::IFrameworkElementOverrides, winrt::Microsoft::UI::Xaml::IUIElementOverrides, I...>,
        impl::require<D, winrt::Microsoft::UI::Xaml::Controls::IPage, winrt::Microsoft::UI::Xaml::Controls::IUserControl, winrt::Microsoft::UI::Xaml::Controls::IControl, winrt::Microsoft::UI::Xaml::Controls::IControlProtected, winrt::Microsoft::UI::Xaml::IFrameworkElement, winrt::Microsoft::UI::Xaml::IFrameworkElementProtected, winrt::Microsoft::UI::Xaml::IUIElement, winrt::Microsoft::UI::Xaml::IUIElementProtected, winrt::Microsoft::UI::Composition::IAnimationObject, winrt::Microsoft::UI::Composition::IVisualElement, winrt::Microsoft::UI::Composition::IVisualElement2, winrt::Microsoft::UI::Xaml::IDependencyObject>,
        impl::base<D, winrt::Microsoft::UI::Xaml::Controls::Page, winrt::Microsoft::UI::Xaml::Controls::UserControl, winrt::Microsoft::UI::Xaml::Controls::Control, winrt::Microsoft::UI::Xaml::FrameworkElement, winrt::Microsoft::UI::Xaml::UIElement, winrt::Microsoft::UI::Xaml::DependencyObject>,
        winrt::Microsoft::UI::Xaml::Controls::IPageOverridesT<D>, winrt::Microsoft::UI::Xaml::Controls::IControlOverridesT<D>, winrt::Microsoft::UI::Xaml::IFrameworkElementOverridesT<D>, winrt::Microsoft::UI::Xaml::IUIElementOverridesT<D>
    {
        using base_type = PlaylistsPage_base;
        using class_type = DisenchantMusicPlayer::PlaylistsPage;
        using implements_type = typename PlaylistsPage_base::implements_type;
        using implements_type::implements_type;
        using composable_base = winrt::Microsoft::UI::Xaml::Controls::Page;
        hstring GetRuntimeClassName() const
        {
            return L"DisenchantMusicPlayer.PlaylistsPage";
        }
        PlaylistsPage_base()
        {
            impl::call_factory<winrt::Microsoft::UI::Xaml::Controls::Page, winrt::Microsoft::UI::Xaml::Controls::IPageFactory>([&](winrt::Microsoft::UI::Xaml::Controls::IPageFactory const& f) { [[maybe_unused]] auto winrt_impl_discarded = f.CreateInstance(*this, this->m_inner); });
        }
    };
}
namespace winrt::DisenchantMusicPlayer::factory_implementation
{
    template <typename D, typename T, typename... I>
    struct __declspec(empty_bases) PlaylistsPageT : implements<D, winrt::Windows::Foundation::IActivationFactory, I...>
    {
        using instance_type = DisenchantMusicPlayer::PlaylistsPage;

        hstring GetRuntimeClassName() const
        {
            return L"DisenchantMusicPlayer.PlaylistsPage";
        }
        auto ActivateInstance() const
        {
            return make<T>();
        }
    };
}

#if defined(WINRT_FORCE_INCLUDE_PLAYLISTSPAGE_XAML_G_H) || __has_include("PlaylistsPage.xaml.g.h")

#include "PlaylistsPage.xaml.g.h"

#else

namespace winrt::DisenchantMusicPlayer::implementation
{
    template <typename D, typename... I>
    using PlaylistsPageT = PlaylistsPage_base<D, I...>;
}

#endif
