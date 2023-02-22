// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#include "pch.h"
#include "SonglistPage.xaml.h"
#if __has_include("SonglistPage.g.cpp")
#include "SonglistPage.g.cpp"
#endif

using namespace winrt;
using namespace Microsoft::UI::Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winrt::DisenchantMusicPlayer::implementation
{
    SonglistPage::SonglistPage()
    {
        InitializeComponent();

        //auto myDataList = winrt::single_threaded_observable_vector<SonglistItem>();
        std::vector<Windows::Foundation::IInspectable> myDataList;
        std::vector<SonglistItem> SonglistData;
        SonglistItem item1 = SonglistItem::SonglistItem(L"Song1",L"Album1",L"ms-appx:///Assets/Images/Cover.jpg");
        SonglistItem item2 = SonglistItem::SonglistItem(L"Song2",L"Album2",L"ms-appx:///Assets/Images/Cover.jpg");
        SonglistData.push_back(item1);
        SonglistData.push_back(item2);
        SonglistView().ItemsSource(single_threaded_observable_vector(std::move(SonglistData)));
        //SonglistItem item1 = make<SonglistItem>();
        //item1.Name(L"Song1");
        //item1.Cover(L"ms-appx:///Assets/Images/Cover.jpg");
        //item1.Album(L"Album1");

        //myDataList.Append(item1);
        //myDataList.push_back
        //myDataList.push_back(item1);

        //SonglistItem item2;
        //item2.Name(L"Song2");
        //item2.Cover(L"ms-appx:///Assets/Images/Cover.jpg");
        //item2.Album(L"Album2");

        //myDataList.Append(item2);

        //SonglistView().ItemsSource(myDataList);

    }

    int32_t SonglistPage::MyProperty()
    {
        throw hresult_not_implemented();
    }

    void SonglistPage::MyProperty(int32_t /* value */)
    {
        throw hresult_not_implemented();
    }

    
}

