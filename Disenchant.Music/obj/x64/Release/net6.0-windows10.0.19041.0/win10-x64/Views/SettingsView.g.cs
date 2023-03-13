﻿#pragma checksum "C:\Users\DenryDu\Documents\MyWork\WinUI3\Disenchant.Music\Disenchant.Music\Views\SettingsView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "101D595AF48FC563DD702EB36AA2577630F6B9CBC76F0E01155F8FDEFDBBB84D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Disenchant.Music.Views
{
    partial class SettingsView : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(global::Microsoft.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class SettingsView_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            ISettingsView_Bindings
        {
            private global::Disenchant.Music.Views.SettingsView dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj2;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj3;
            private global::Microsoft.UI.Xaml.Controls.Button obj4;
            private global::Microsoft.UI.Xaml.Controls.Button obj5;

            // Fields for each event bindings event handler.
            private global::Microsoft.UI.Xaml.RoutedEventHandler obj4Click;
            private global::Microsoft.UI.Xaml.RoutedEventHandler obj5Click;

            private SettingsView_obj1_BindingsTracking bindingsTracking;

            public SettingsView_obj1_Bindings()
            {
                this.bindingsTracking = new SettingsView_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Views\SettingsView.xaml line 20
                        this.obj2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    case 3: // Views\SettingsView.xaml line 22
                        this.obj3 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        this.bindingsTracking.RegisterTwoWayListener_3(this.obj3);
                        break;
                    case 4: // Views\SettingsView.xaml line 23
                        this.obj4 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                        this.obj4Click = (global::System.Object p0, global::Microsoft.UI.Xaml.RoutedEventArgs p1) =>
                        {
                            this.dataRoot.settingsViewModel.PickFolderButton_Click(p0, p1);
                        };
                        (global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target)).Click += obj4Click;
                        break;
                    case 5: // Views\SettingsView.xaml line 24
                        this.obj5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                        this.obj5Click = (global::System.Object p0, global::Microsoft.UI.Xaml.RoutedEventArgs p1) =>
                        {
                            this.dataRoot.settingsViewModel.CancelFolderButton_Click(p0, p1);
                        };
                        (global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target)).Click += obj5Click;
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            // ISettingsView_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::Disenchant.Music.Views.SettingsView>(newDataRoot);
                    return true;
                }
                return false;
            }

            public void Activated(object obj, global::Microsoft.UI.Xaml.WindowActivatedEventArgs data)
            {
                this.Initialize();
            }

            public void Loading(global::Microsoft.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Disenchant.Music.Views.SettingsView obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_settingsViewModel(obj.settingsViewModel, phase);
                    }
                }
            }
            private void Update_settingsViewModel(global::Disenchant.Music.ViewModels.SettingsViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_settingsViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_settingsViewModel_SelectFolderTitle(obj.SelectFolderTitle, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_settingsViewModel_SelectedFolderText(obj.SelectedFolderText, phase);
                    }
                }
            }
            private void Update_settingsViewModel_SelectFolderTitle(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\SettingsView.xaml line 20
                    XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj2, obj, null);
                }
            }
            private void Update_settingsViewModel_SelectedFolderText(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\SettingsView.xaml line 22
                    XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj3, obj, null);
                }
            }
            private void UpdateTwoWay_3_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.settingsViewModel != null)
                        {
                            this.dataRoot.settingsViewModel.SelectedFolderText = this.obj3.Text;
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class SettingsView_obj1_BindingsTracking
            {
                private global::System.WeakReference<SettingsView_obj1_Bindings> weakRefToBindingObj; 

                public SettingsView_obj1_BindingsTracking(SettingsView_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<SettingsView_obj1_Bindings>(obj);
                }

                public SettingsView_obj1_Bindings TryGetBindingObject()
                {
                    SettingsView_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_settingsViewModel(null);
                }

                public void PropertyChanged_settingsViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    SettingsView_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::Disenchant.Music.ViewModels.SettingsViewModel obj = sender as global::Disenchant.Music.ViewModels.SettingsViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_settingsViewModel_SelectedFolderText(obj.SelectedFolderText, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "SelectedFolderText":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_settingsViewModel_SelectedFolderText(obj.SelectedFolderText, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::Disenchant.Music.ViewModels.SettingsViewModel cache_settingsViewModel = null;
                public void UpdateChildListeners_settingsViewModel(global::Disenchant.Music.ViewModels.SettingsViewModel obj)
                {
                    if (obj != cache_settingsViewModel)
                    {
                        if (cache_settingsViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_settingsViewModel).PropertyChanged -= PropertyChanged_settingsViewModel;
                            cache_settingsViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_settingsViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_settingsViewModel;
                        }
                    }
                }
                public void RegisterTwoWayListener_3(global::Microsoft.UI.Xaml.Controls.TextBlock sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Microsoft.UI.Xaml.Controls.TextBlock.TextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_3_Text();
                        }
                    });
                }
            }
        }

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 4: // Views\SettingsView.xaml line 23
                {
                    this.PickFolderButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                }
                break;
            case 5: // Views\SettingsView.xaml line 24
                {
                    this.CancelFolderButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\SettingsView.xaml line 4
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    SettingsView_obj1_Bindings bindings = new SettingsView_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

