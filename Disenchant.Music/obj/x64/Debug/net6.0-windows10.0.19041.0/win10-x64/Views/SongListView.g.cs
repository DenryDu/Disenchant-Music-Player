﻿#pragma checksum "C:\Users\DenryDu\Documents\MyWork\WinUI3\新建文件夹\Disenchant.Music\Views\SongListView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0F0E289870E1E86AA5A680B39EF12312F28FDE0914D029EFC2A182859737BF8E"
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
    partial class SongListView : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Microsoft.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(global::Microsoft.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_Image_Source(global::Microsoft.UI.Xaml.Controls.Image obj, global::Microsoft.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Microsoft.UI.Xaml.Media.ImageSource) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Microsoft.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class SongListView_obj4_Bindings :
            global::Microsoft.UI.Xaml.IDataTemplateExtension,
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            ISongListView_Bindings
        {
            private global::Disenchant.Music.Models.MusicInfo dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj4;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj5;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj6;
            private global::Microsoft.UI.Xaml.Controls.Image obj7;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj5TextDisabled = false;
            private static bool isobj6TextDisabled = false;
            private static bool isobj7SourceDisabled = false;

            public SongListView_obj4_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 37 && columnNumber == 36)
                {
                    isobj5TextDisabled = true;
                }
                else if (lineNumber == 38 && columnNumber == 36)
                {
                    isobj6TextDisabled = true;
                }
                else if (lineNumber == 34 && columnNumber == 51)
                {
                    isobj7SourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4: // Views\SongListView.xaml line 28
                        this.obj4 = new global::System.WeakReference(global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target));
                        break;
                    case 5: // Views\SongListView.xaml line 37
                        this.obj5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    case 6: // Views\SongListView.xaml line 38
                        this.obj6 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    case 7: // Views\SongListView.xaml line 34
                        this.obj7 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Image>(target);
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

            public void DataContextChangedHandler(global::Microsoft.UI.Xaml.FrameworkElement sender, global::Microsoft.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Microsoft.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = 1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj4.Target as global::Microsoft.UI.Xaml.Controls.Grid).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                    case 1:
                        global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ResumeRendering(this.obj6);
                        nextPhase = 2;
                        break;
                    case 2:
                        global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ResumeRendering(this.obj7);
                        nextPhase = -1;
                        break;
                }
                this.Update_(global::WinRT.CastExtensions.As<global::Disenchant.Music.Models.MusicInfo>(item), 1 << phase);
            }

            public void Recycle()
            {
                global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SuspendRendering(this.obj6);
                global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SuspendRendering(this.obj7);
            }

            // ISongListView_Bindings

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
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::Disenchant.Music.Models.MusicInfo>(newDataRoot);
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Disenchant.Music.Models.MusicInfo obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Title(obj.Title, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0) | (1 << 1))) != 0)
                    {
                        this.Update_ArtistsAndAlbumStr(obj.ArtistsAndAlbumStr, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0) | (1 << 2))) != 0)
                    {
                        this.Update_Cover(obj.Cover, phase);
                    }
                }
            }
            private void Update_Title(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\SongListView.xaml line 37
                    if (!isobj5TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj, null);
                    }
                }
            }
            private void Update_ArtistsAndAlbumStr(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 1) | NOT_PHASED )) != 0)
                {
                    // Views\SongListView.xaml line 38
                    if (!isobj6TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj6, obj, null);
                    }
                }
            }
            private void Update_Cover(global::Microsoft.UI.Xaml.Media.Imaging.BitmapImage obj, int phase)
            {
                if ((phase & ((1 << 2) | NOT_PHASED )) != 0)
                {
                    // Views\SongListView.xaml line 34
                    if (!isobj7SourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_Image_Source(this.obj7, obj, null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class SongListView_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            ISongListView_Bindings
        {
            private global::Disenchant.Music.Views.SongListView dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.ListView obj2;

            // Fields for each event bindings event handler.
            private global::Microsoft.UI.Xaml.Controls.SelectionChangedEventHandler obj2SelectionChanged;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2ItemsSourceDisabled = false;

            private SongListView_obj1_BindingsTracking bindingsTracking;

            public SongListView_obj1_Bindings()
            {
                this.bindingsTracking = new SongListView_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 16 && columnNumber == 15)
                {
                    isobj2ItemsSourceDisabled = true;
                }
                else if (lineNumber == 17 && columnNumber == 15)
                {
                    this.obj2.SelectionChanged -= obj2SelectionChanged;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Views\SongListView.xaml line 15
                        this.obj2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
                        this.obj2SelectionChanged = (global::System.Object p0, global::Microsoft.UI.Xaml.Controls.SelectionChangedEventArgs p1) =>
                        {
                            this.dataRoot.songListViewModel.SonglistView_SelectionChanged(p0, p1);
                        };
                        (global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target)).SelectionChanged += obj2SelectionChanged;
                        this.bindingsTracking.RegisterTwoWayListener_2(this.obj2);
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

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // ISongListView_Bindings

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
                    this.dataRoot = global::WinRT.CastExtensions.As<global::Disenchant.Music.Views.SongListView>(newDataRoot);
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
            private void Update_(global::Disenchant.Music.Views.SongListView obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_songListViewModel(obj.songListViewModel, phase);
                    }
                }
            }
            private void Update_songListViewModel(global::Disenchant.Music.ViewModels.SongListViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_songListViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_songListViewModel_SongList(obj.SongList, phase);
                    }
                }
            }
            private void Update_songListViewModel_SongList(global::System.Collections.ObjectModel.ObservableCollection<global::Disenchant.Music.Models.MusicInfo> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_songListViewModel_SongList(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\SongListView.xaml line 15
                    if (!isobj2ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj2, obj, null);
                    }
                }
            }
            private void UpdateTwoWay_2_ItemsSource()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.songListViewModel != null)
                        {
                            this.dataRoot.songListViewModel.SongList = (global::System.Collections.ObjectModel.ObservableCollection<global::Disenchant.Music.Models.MusicInfo>)this.obj2.ItemsSource;
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class SongListView_obj1_BindingsTracking
            {
                private global::System.WeakReference<SongListView_obj1_Bindings> weakRefToBindingObj; 

                public SongListView_obj1_BindingsTracking(SongListView_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<SongListView_obj1_Bindings>(obj);
                }

                public SongListView_obj1_Bindings TryGetBindingObject()
                {
                    SongListView_obj1_Bindings bindingObject = null;
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
                    UpdateChildListeners_songListViewModel(null);
                    UpdateChildListeners_songListViewModel_SongList(null);
                }

                public void PropertyChanged_songListViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    SongListView_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::Disenchant.Music.ViewModels.SongListViewModel obj = sender as global::Disenchant.Music.ViewModels.SongListViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_songListViewModel_SongList(obj.SongList, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "SongList":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_songListViewModel_SongList(obj.SongList, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::Disenchant.Music.ViewModels.SongListViewModel cache_songListViewModel = null;
                public void UpdateChildListeners_songListViewModel(global::Disenchant.Music.ViewModels.SongListViewModel obj)
                {
                    if (obj != cache_songListViewModel)
                    {
                        if (cache_songListViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_songListViewModel).PropertyChanged -= PropertyChanged_songListViewModel;
                            cache_songListViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_songListViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_songListViewModel;
                        }
                    }
                }
                public void PropertyChanged_songListViewModel_SongList(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    SongListView_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::Disenchant.Music.Models.MusicInfo> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Disenchant.Music.Models.MusicInfo>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_songListViewModel_SongList(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    SongListView_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::Disenchant.Music.Models.MusicInfo> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Disenchant.Music.Models.MusicInfo>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::Disenchant.Music.Models.MusicInfo> cache_songListViewModel_SongList = null;
                public void UpdateChildListeners_songListViewModel_SongList(global::System.Collections.ObjectModel.ObservableCollection<global::Disenchant.Music.Models.MusicInfo> obj)
                {
                    if (obj != cache_songListViewModel_SongList)
                    {
                        if (cache_songListViewModel_SongList != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_songListViewModel_SongList).PropertyChanged -= PropertyChanged_songListViewModel_SongList;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_songListViewModel_SongList).CollectionChanged -= CollectionChanged_songListViewModel_SongList;
                            cache_songListViewModel_SongList = null;
                        }
                        if (obj != null)
                        {
                            cache_songListViewModel_SongList = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_songListViewModel_SongList;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_songListViewModel_SongList;
                        }
                    }
                }
                public void RegisterTwoWayListener_2(global::Microsoft.UI.Xaml.Controls.ListView sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Microsoft.UI.Xaml.Controls.ItemsControl.ItemsSourceProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_2_ItemsSource();
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
            case 2: // Views\SongListView.xaml line 15
                {
                    this.SonglistView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
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
            case 1: // Views\SongListView.xaml line 4
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    SongListView_obj1_Bindings bindings = new SongListView_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            case 4: // Views\SongListView.xaml line 28
                {                    
                    global::Microsoft.UI.Xaml.Controls.Grid element4 = (global::Microsoft.UI.Xaml.Controls.Grid)target;
                    SongListView_obj4_Bindings bindings = new SongListView_obj4_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element4.DataContext);
                    element4.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Microsoft.UI.Xaml.DataTemplate.SetExtensionInstance(element4, bindings);
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element4, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

