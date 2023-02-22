// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#include "pch.h"
#include "ArtistlistPage.xaml.h"
#if __has_include("ArtistlistPage.g.cpp")
#include "ArtistlistPage.g.cpp"
#endif

using namespace winrt;
using namespace Microsoft::UI::Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winrt::DisenchantMusicPlayer::implementation
{
    ArtistlistPage::ArtistlistPage()
    {
        InitializeComponent();
    }

    int32_t ArtistlistPage::MyProperty()
    {
        throw hresult_not_implemented();
    }

    void ArtistlistPage::MyProperty(int32_t /* value */)
    {
        throw hresult_not_implemented();
    }

}
