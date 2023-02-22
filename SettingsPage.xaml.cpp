// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#include "pch.h"
#include "SettingsPage.xaml.h"
#if __has_include("SettingsPage.g.cpp")
#include "SettingsPage.g.cpp"
#endif

using namespace winrt;
using namespace Microsoft::UI::Xaml;

using namespace Windows::Foundation;
using namespace Windows::Storage;
using namespace Windows::Storage::AccessCache;
using namespace Windows::Storage::Pickers;
//using namespace Windows::UI::Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winrt::DisenchantMusicPlayer::implementation
{
    SettingsPage::SettingsPage()
    {
        InitializeComponent();
    }

    int32_t SettingsPage::MyProperty()
    {
        throw hresult_not_implemented();
    }

    void SettingsPage::MyProperty(int32_t /* value */)
    {
        throw hresult_not_implemented();
    }

    fire_and_forget SettingsPage::PickFolderButton_Click(Windows::Foundation::IInspectable const&, Microsoft::UI::Xaml::RoutedEventArgs const&)
    {
        auto lifetime = get_strong();

        // Clear previous returned folder name, if it exists, between iterations of this scenario
        OutputTextBlock().Text(L"");

        FolderPicker folderPicker;
        folderPicker.SuggestedStartLocation(PickerLocationId::Desktop);
        folderPicker.FileTypeFilter().ReplaceAll({ L".docx",  L".xlsx", L".pptx" });
        StorageFolder folder = co_await folderPicker.PickSingleFolderAsync();
        if (folder != nullptr)
        {
            // The StorageFolder has read/write access to all contents in the picked folder (including other sub-folder contents).
            // See the FileAccess sample for code that obtains a StorageFile from a StorageFolder to read and write.
            StorageApplicationPermissions::FutureAccessList().AddOrReplace(L"PickedFolderToken", folder);
            OutputTextBlock().Text(L"Picked folder: " + folder.Name());
        }
        else
        {
            OutputTextBlock().Text(L"Operation cancelled.");
        }
    }

}
