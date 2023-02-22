﻿//------------------------------------------------------------------------------
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//------------------------------------------------------------------------------
#pragma once

#include "XamlBindingInfo.xaml.g.h"

namespace winrt::DisenchantMusicPlayer::implementation
{
    using IInspectable = ::winrt::Windows::Foundation::IInspectable;

    template <typename D, typename ... I>
    struct SonglistPageT : public ::winrt::DisenchantMusicPlayer::implementation::SonglistPage_base<D,
        ::winrt::Microsoft::UI::Xaml::Markup::IComponentConnector,
        I...>
    {
        using base_type = typename SonglistPageT::base_type;
        using base_type::base_type;
        using class_type = typename SonglistPageT::class_type;

        void InitializeComponent();
        virtual void Connect(int32_t connectionId, IInspectable const& target);
        virtual ::winrt::Microsoft::UI::Xaml::Markup::IComponentConnector GetBindingConnector(int32_t connectionId, IInspectable const& target);
        void UnloadObject(::winrt::Microsoft::UI::Xaml::DependencyObject const& dependencyObject);
        void DisconnectUnloadedObject(int32_t connectionId);

        ::winrt::Microsoft::UI::Xaml::Controls::ListView SonglistView()
        {
            return _SonglistView;
        }
        void SonglistView(::winrt::Microsoft::UI::Xaml::Controls::ListView value)
        {
            _SonglistView = value;
        }
        
         ::winrt::com_ptr<::winrt::DisenchantMusicPlayer::implementation::XamlBindings> Bindings;

    protected:
        bool _contentLoaded{false};

    private:
        struct SonglistPage_obj4_Bindings;
        struct SonglistPage_obj1_Bindings;

        ::winrt::Microsoft::UI::Xaml::Controls::ListView _SonglistView{nullptr};
    };
}

