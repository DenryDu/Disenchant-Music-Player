using DisenchantMusicPlayer.Helpers;
using DisenchantMusicPlayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;

namespace DisenchantMusicPlayer.ViewModel
{
    internal class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public SettingsViewModel() 
        {
            SelectFolderTitle = "音乐库文件夹";
            SelectedFolderText = AsyncHelper.RunSync(async () =>
            {
                try
                {
                    StorageFolder folder = await StorageApplicationPermissions.FutureAccessList.GetFolderAsync(GlobalData.MusicLibraryFolderToken);
                    return folder.Path;
                }
                catch (System.ArgumentException e)
                {
                    return "文件夹尚未指定";
                }
            }) ?? "";            
        }

        // 选定文件夹路径
        private string _selectedFolderText;
        public string SelectedFolderText { get { return _selectedFolderText; } set { _selectedFolderText = value; OnPropertyChanged(nameof(SelectedFolderText)); } }

        private string _selectFolderTitle;
        public string SelectFolderTitle { get { return _selectFolderTitle; } set { _selectFolderTitle = value; OnPropertyChanged(name: nameof(SelectFolderTitle)); } }

        public async void PickFolderButton_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            foreach(string filetype in GlobalData.SupportedAudioTypes)
            {
                folderPicker.FileTypeFilter.Add(filetype);
            }
            GlobalData.MusicLibrary.Folder = await folderPicker.PickSingleFolderAsync();
            if (GlobalData.MusicLibrary.Folder != null)
            {
                // The StorageFolder has read/write access to all contents in the picked folder (including other sub-folder contents).
                // See the FileAccess sample for code that obtains a StorageFile from a StorageFolder to read and write.
                //StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", musicLibrary.Folder);
                StorageApplicationPermissions.FutureAccessList.AddOrReplace(GlobalData.MusicLibraryFolderToken, GlobalData.MusicLibrary.Folder);
                //StorageApplicationPermissions.FutureAccessList.Remove(GlobalData.MusicLibraryFolderToken);
                SelectedFolderText = GlobalData.MusicLibrary.Folder.Path;
                GlobalData.MusicLibrary.InitMusics();
            }
            else
            {
                SelectedFolderText = "Operation cancelled.";
            }
        }
        public void CancelFolderButton_Click(object sender, RoutedEventArgs e)
        {
            StorageApplicationPermissions.FutureAccessList.Remove(GlobalData.MusicLibraryFolderToken);
            GlobalData.MusicLibrary = new MusicLibrary();
            SelectedFolderText = "文件夹尚未指定";
        }

    }
}
