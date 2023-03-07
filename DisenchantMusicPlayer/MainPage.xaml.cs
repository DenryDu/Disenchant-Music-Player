using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using TagLib;
using Windows.UI.Xaml.Shapes;
using System.Diagnostics;
using DisenchantMusicPlayer.Model;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.Storage;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace DisenchantMusicPlayer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //MusicInfo.folderPath = "C:\\Users\\DenryDu\\OneDrive\\音频\\Music";
            string folderPath = "./Assets/"; ;
            musicLibrary = new MusicLibrary();
            //musicLibrary.InitMusics();
            string path1 = "test.flac";
            string path2 = "test2.flac";
            string path3 = "test3.flac";
            //music1 = new MusicInfo(folderPath + path1);
            //MusicInfo music2 = new MusicInfo(folderPath + path2);
            //MusicInfo music3 = new MusicInfo(folderPath + path3);
        }

        MusicInfo music1;
        MusicLibrary musicLibrary;
        private async void PickFolderButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous returned folder name, if it exists, between iterations of this scenario
            OutputTextBlock.Text = "";

            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add(".mp3");
            folderPicker.FileTypeFilter.Add(".m4a");
            folderPicker.FileTypeFilter.Add(".wav");
            folderPicker.FileTypeFilter.Add(".flac");
            folderPicker.FileTypeFilter.Add(".aac");
            folderPicker.FileTypeFilter.Add(".wma");
            folderPicker.FileTypeFilter.Add(".ogg");
            folderPicker.FileTypeFilter.Add(".oga");
            folderPicker.FileTypeFilter.Add(".m3u");
            folderPicker.FileTypeFilter.Add(".m3u8");
            folderPicker.FileTypeFilter.Add(".wpl");
            folderPicker.FileTypeFilter.Add(".zpl");
            musicLibrary.Folder = await folderPicker.PickSingleFolderAsync();
            if (musicLibrary.Folder != null)
            {
                // The StorageFolder has read/write access to all contents in the picked folder (including other sub-folder contents).
                // See the FileAccess sample for code that obtains a StorageFile from a StorageFolder to read and write.
                //StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", musicLibrary.Folder);
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("musicLibrary", musicLibrary.Folder);
                //StorageApplicationPermissions.FutureAccessList.
                OutputTextBlock.Text = "Picked folder: " + musicLibrary.Folder.Name;
                //musicLibrary.FolderPath = "C:/Users/DenryDu/OneDrive/音频/Music/";
                Debug.WriteLine(musicLibrary.Folder.Path);
                musicLibrary.InitMusics();
                //folder.

            }
            else
            {
                OutputTextBlock.Text = "Operation cancelled.";
            }
        }

    }
}
