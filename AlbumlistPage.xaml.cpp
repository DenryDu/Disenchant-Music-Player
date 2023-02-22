// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#include "pch.h"
#include "AlbumlistPage.xaml.h"
#if __has_include("AlbumlistPage.g.cpp")
#include "AlbumlistPage.g.cpp"
#endif

using namespace winrt;
using namespace Microsoft::UI::Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winrt::DisenchantMusicPlayer::implementation
{
    AlbumlistPage::AlbumlistPage()
    {
        InitializeComponent();
    }

    int32_t AlbumlistPage::MyProperty()
    {
        throw hresult_not_implemented();
    }

    void AlbumlistPage::MyProperty(int32_t /* value */)
    {
        throw hresult_not_implemented();
    }

}
