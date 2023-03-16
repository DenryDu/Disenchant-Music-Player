// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Disenchant.Music.Model;
using Disenchant.Music.ViewModel;
using Disenchant.Music.Views;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.VisualBasic.Devices;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using Windows.Devices.Radios;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static Disenchant.Music.Model.AudioPlayer;
using static System.Windows.Forms.DataFormats;
using Button = Microsoft.UI.Xaml.Controls.Button;
//using System.Runtime.InteropServices; // For DllImport
using WinRT; // required to support Window.As<ICompositionSupportsSystemBackdrop>()
using Disenchant.Music.Helpers;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Disenchant.Music
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        WindowsSystemDispatcherQueueHelper m_wsdqHelper; // See separate sample below for implementation
        Microsoft.UI.Composition.SystemBackdrops.DesktopAcrylicController m_acrylicController;
        Microsoft.UI.Composition.SystemBackdrops.SystemBackdropConfiguration m_configurationSource;


        //  
        IntPtr hWnd = IntPtr.Zero;
        private SUBCLASSPROC SubClassDelegate;
        public MainWindow()
        {
            this.InitializeComponent();
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
         
            if (localSettings.Values["IsAcrylic"] == null)
            {
                localSettings.Values["IsAcrylic"] = true;
            }
            bool IsAcrylic = (bool)localSettings.Values["IsAcrylic"];
            if (IsAcrylic)
            {
                TrySetAcrylicBackdrop();
            }

            // Set Title
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);

            RootNavFrame.Navigate(typeof(RootNavView));
            RootPlayBarFrame.Navigate(typeof(RootPlayBarView));

            mainViewModel = new MainViewModel();
            MainViewModel.MainWindow = this;
            GlobalData.MainWindow = this;

   

            // after this.InitializeComponent();  
            hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);

            SubClassDelegate = new SUBCLASSPROC(WindowSubClass);
            bool bReturn = SetWindowSubclass(hWnd, SubClassDelegate, 0, 0);


            // Retrieve the window handle (HWND) of the current (XAML) WinUI 3 window.
            //var AnotherhWnd =
            //    WinRT.Interop.WindowNative.GetWindowHandle(this);

            // Retrieve the WindowId that corresponds to hWnd.
            Microsoft.UI.WindowId windowId =
                Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);

            // Lastly, retrieve the AppWindow for the current (XAML) WinUI 3 window.
            GlobalData.AppWindow =
                Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            /*
            // Retrieve the window handle (HWND) of the current (XAML) WinUI 3 window.
            var hWnd =
                WinRT.Interop.WindowNative.GetWindowHandle(this);

            // Retrieve the WindowId that corresponds to hWnd.
            Microsoft.UI.WindowId windowId =
                Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);

            // Lastly, retrieve the AppWindow for the current (XAML) WinUI 3 window.
            Microsoft.UI.Windowing.AppWindow appWindow =
                Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);

            
            this.SizeChanged += (s, e) =>
            {
                if (e.Size.Height < 716 || e.Size.Width <424)
                {
                    appWindow.Resize(new Windows.Graphics.SizeInt32(Math.Max(716,(int)e.Size.Height), Math.Max(424,(int)e.Size.Width)));
                }
                //Debug.WriteLine(s);

            };
            */
            //ApplicationView.PreferredLaunchViewSize = new Size(height: 716, width: 424);
            //GlobalData.CurrentWindow.se
            //view.SetPreferredMinSize(new Size { Width = 300, Height = 200 });
        }

        internal MainViewModel mainViewModel;
        public Frame GetRootNavFrame()
        {
            return RootNavFrame;
        }

        //////////////////////////////////////     Use Acrylic    //////////////////////////////////////////////////////


        bool TrySetAcrylicBackdrop()
        {
            if (Microsoft.UI.Composition.SystemBackdrops.DesktopAcrylicController.IsSupported())
            {
                m_wsdqHelper = new WindowsSystemDispatcherQueueHelper();
                m_wsdqHelper.EnsureWindowsSystemDispatcherQueueController();

                // Hooking up the policy object
                m_configurationSource = new Microsoft.UI.Composition.SystemBackdrops.SystemBackdropConfiguration();
                this.Activated += Window_Activated;
                this.Closed += Window_Closed;
                ((FrameworkElement)this.Content).ActualThemeChanged += Window_ThemeChanged;

                // Initial configuration state.
                m_configurationSource.IsInputActive = true;
                SetConfigurationSourceTheme();

                m_acrylicController = new Microsoft.UI.Composition.SystemBackdrops.DesktopAcrylicController();

                // Enable the system backdrop.
                // Note: Be sure to have "using WinRT;" to support the Window.As<...>() call.
                m_acrylicController.AddSystemBackdropTarget(this.As<Microsoft.UI.Composition.ICompositionSupportsSystemBackdrop>());
                m_acrylicController.SetSystemBackdropConfiguration(m_configurationSource);
                return true; // succeeded
            }

            return false; // Acrylic is not supported on this system
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            m_configurationSource.IsInputActive = args.WindowActivationState != WindowActivationState.Deactivated;
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            // Make sure any Mica/Acrylic controller is disposed so it doesn't try to
            // use this closed window.
            if (m_acrylicController != null)
            {
                m_acrylicController.Dispose();
                m_acrylicController = null;
            }
            this.Activated -= Window_Activated;
            m_configurationSource = null;
        }

        private void Window_ThemeChanged(FrameworkElement sender, object args)
        {
            if (m_configurationSource != null)
            {
                SetConfigurationSourceTheme();
            }
        }

        private void SetConfigurationSourceTheme()
        {
            switch (((FrameworkElement)this.Content).ActualTheme)
            {
                case ElementTheme.Dark: m_configurationSource.Theme = Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme.Dark; break;
                case ElementTheme.Light: m_configurationSource.Theme = Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme.Light; break;
                case ElementTheme.Default: m_configurationSource.Theme = Microsoft.UI.Composition.SystemBackdrops.SystemBackdropTheme.Default; break;
            }
        }





        /////////////////////////////////////////      Set MinSize    ////////////////////////////////////////////////////
     
  

        //  
        private int WindowSubClass(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData)
        {
            switch (uMsg)
            {
                case WM_GETMINMAXINFO:
                    {
                        MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
                        mmi.ptMinTrackSize.X = 444;
                        mmi.ptMinTrackSize.Y = 726;
                        Marshal.StructureToPtr(mmi, lParam, false);
                        return 0;
                    }
                    break;
            }
            return DefSubclassProc(hWnd, uMsg, wParam, lParam);
        }


        public delegate int SUBCLASSPROC(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern bool SetWindowSubclass(IntPtr hWnd, SUBCLASSPROC pfnSubclass, uint uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern int DefSubclassProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        public const int WM_GETMINMAXINFO = 0x0024;

        public struct MINMAXINFO
        {
            public System.Drawing.Point ptReserved;
            public System.Drawing.Point ptMaxSize;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Point ptMinTrackSize;
            public System.Drawing.Point ptMaxTrackSize;
        }
    }
}
