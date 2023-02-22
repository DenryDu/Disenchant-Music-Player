// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#include "pch.h"
#include "StatisticPage.xaml.h"
#if __has_include("StatisticPage.g.cpp")
#include "StatisticPage.g.cpp"
#endif

using namespace winrt;
using namespace Microsoft::UI::Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winrt::DisenchantMusicPlayer::implementation
{
    StatisticPage::StatisticPage()
    {
        InitializeComponent();
            }

    int32_t StatisticPage::MyProperty()
    {
        throw hresult_not_implemented();
    }

    void StatisticPage::MyProperty(int32_t /* value */)
    {
        throw hresult_not_implemented();
    }

}
