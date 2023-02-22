// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#include "pch.h"
#include "MainWindow.xaml.h"
#if __has_include("MainWindow.g.cpp")
#include "MainWindow.g.cpp"
#endif

using namespace winrt;
using namespace Microsoft::UI::Xaml;

#include <winrt/Windows.UI.ViewManagement.h>

using namespace winrt;
using namespace Windows::UI::ViewManagement;

#include <winrt/Windows.UI.Core.h>

using namespace winrt;
using namespace Windows::UI::Core;
#include <winrt/Windows.ApplicationModel.Core.h>

using namespace winrt::Windows::ApplicationModel::Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winrt::DisenchantMusicPlayer::implementation
{
    MainWindow::MainWindow()
    {
        InitializeComponent();// 初始化 COM 和窗口

		// Navigate to Settings.
		Windows::UI::Xaml::Interop::TypeName pageTypeName;
		pageTypeName.Kind = Windows::UI::Xaml::Interop::TypeKind::Primitive;
		pageTypeName.Name = L"DisenchantMusicPlayer.SonglistPage";
		RNavContentFrame().Navigate(pageTypeName);


	}



    int32_t MainWindow::MyProperty()
    {
        throw hresult_not_implemented();
    }

    void MainWindow::MyProperty(int32_t /* value */)
    {
        throw hresult_not_implemented();
    }

	void MainWindow::NavView_ItemInvoked(
		Windows::Foundation::IInspectable const& /* sender */,
		muxc::NavigationViewItemInvokedEventArgs const& args)
	{

		Windows::UI::Xaml::Interop::TypeName pageTypeName;
		pageTypeName.Kind = Windows::UI::Xaml::Interop::TypeKind::Primitive;

		if (args.IsSettingsInvoked())
		{
			// Navigate to Settings.
			pageTypeName.Name = L"DisenchantMusicPlayer.SettingsPage";
			RNavContentFrame().Navigate(pageTypeName);
		}
		else if (args.InvokedItemContainer())
		{
			pageTypeName.Name = unbox_value<hstring>(args.InvokedItemContainer().Tag());
			//RNavContentFrame().Navigate(pageTypeName, nullptr);

			RNavContentFrame().Navigate(pageTypeName);
		}

	}

}



