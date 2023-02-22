// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#include "pch.h"
#include "SonglistPage.xaml.h"
#if __has_include("SonglistPage.g.cpp")
#include "SonglistPage.g.cpp"
#endif

using namespace winrt;
using namespace Microsoft::UI::Xaml;
using namespace Windows::UI::ViewManagement;
using namespace Windows::UI::Core;
using namespace Windows::ApplicationModel::Core;

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

        //auto view = ApplicationView::GetForCurrentView();
        // If this size is not permitted by the system, the nearest permitted value is used.
        //view.SetPreferredMinSize({ 600, 200 });
    }
    void SonglistPage::OnNavigatedTo(Microsoft::UI::Xaml::Navigation::NavigationEventArgs const& e) {

        //// 获取当前视图
        //auto currentView = winrt::Windows::ApplicationModel::Core::CoreApplication::GetCurrentView();
        //// 获取当前窗口
        //auto currentWindow = currentView.CoreWindow();
        //// 获取标题栏
        //auto titleBar = winrt::Windows::ApplicationModel::Core::CoreApplication::GetCurrentView().TitleBar();
        //// 将内容延伸到标题栏
        //titleBar.ExtendViewIntoTitleBar(true);

        // 获取当前应用程序视图
        //auto view = ApplicationView::GetForCurrentView();
        // 创建一个包含最小尺寸的 Size 对象 Size minSize(500, 0);
        // 设置窗口的最小尺寸
        //view.SetPreferredMinSize({ 300,200 });
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

