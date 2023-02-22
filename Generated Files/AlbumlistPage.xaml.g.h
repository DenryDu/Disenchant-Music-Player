﻿//------------------------------------------------------------------------------
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//------------------------------------------------------------------------------
#pragma once


namespace winrt::DisenchantMusicPlayer::implementation
{
    using IInspectable = ::winrt::Windows::Foundation::IInspectable;

    template <typename D, typename ... I>
    struct AlbumlistPageT : public ::winrt::DisenchantMusicPlayer::implementation::AlbumlistPage_base<D,
        ::winrt::Microsoft::UI::Xaml::Markup::IComponentConnector,
        I...>
    {
        using base_type = typename AlbumlistPageT::base_type;
        using base_type::base_type;
        using class_type = typename AlbumlistPageT::class_type;

        void InitializeComponent();
        virtual void Connect(int32_t connectionId, IInspectable const& target);
        virtual ::winrt::Microsoft::UI::Xaml::Markup::IComponentConnector GetBindingConnector(int32_t connectionId, IInspectable const& target);
        void UnloadObject(::winrt::Microsoft::UI::Xaml::DependencyObject const& dependencyObject);
        void DisconnectUnloadedObject(int32_t connectionId);
        
    protected:
        bool _contentLoaded{false};

    private:
        struct AlbumlistPage_obj1_Bindings;

    };
}

