﻿#pragma checksum "E:\Tài liệu môn học\Năm 3 - HKII\Chuyên đề mobile\UIT READER\UIT READER\UITReader\AppShell.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B69C94FFA72CD0AF68E9B398B70F9ACD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UITReader
{
    partial class AppShell : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_UIElement_Visibility(global::Windows.UI.Xaml.UIElement obj, global::Windows.UI.Xaml.Visibility value)
            {
                obj.Visibility = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_FontIcon_Glyph(global::Windows.UI.Xaml.Controls.FontIcon obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Glyph = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(global::Windows.UI.Xaml.FrameworkElement obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                global::Windows.UI.Xaml.Controls.ToolTipService.SetToolTip(obj, value);
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        private class AppShell_obj2_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IAppShell_Bindings
        {
            private global::UITReader.ViewModels.FeedViewModel dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Grid obj3;
            private global::Windows.UI.Xaml.Controls.FontIcon obj4;
            private global::Windows.UI.Xaml.Controls.TextBlock obj5;
            private global::Windows.UI.Xaml.Controls.FontIcon obj6;
            private global::Windows.UI.Xaml.Controls.FontIcon obj7;

            private AppShell_obj2_BindingsTracking bindingsTracking;

            public AppShell_obj2_Bindings()
            {
                this.bindingsTracking = new AppShell_obj2_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3:
                        this.obj3 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.FontIcon)target;
                        break;
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 6:
                        this.obj6 = (global::Windows.UI.Xaml.Controls.FontIcon)target;
                        break;
                    case 7:
                        this.obj7 = (global::Windows.UI.Xaml.Controls.FontIcon)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::UITReader.ViewModels.FeedViewModel data = args.NewValue as global::UITReader.ViewModels.FeedViewModel;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::UITReader.ViewModels.FeedViewModel was expected.");
                 }
                 this.SetDataRoot(data);
                 this.Update();
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(args.Item as global::UITReader.ViewModels.FeedViewModel);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.Grid)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::UITReader.ViewModels.FeedViewModel) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                this.bindingsTracking.ReleaseAllListeners();
            }

            // IAppShell_Bindings

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

            // AppShell_obj2_Bindings

            public void SetDataRoot(global::UITReader.ViewModels.FeedViewModel newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }
            public void SetConverterLookupRoot(global::Windows.UI.Xaml.FrameworkElement rootElement)
            {
                this.converterLookupRoot = new global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement>(rootElement);
            }

            public global::Windows.UI.Xaml.Data.IValueConverter LookupConverter(string key)
            {
                if (this.localResources == null)
                {
                    global::Windows.UI.Xaml.FrameworkElement rootElement;
                    this.converterLookupRoot.TryGetTarget(out rootElement);
                    this.localResources = rootElement.Resources;
                    this.converterLookupRoot = null;
                }
                return (global::Windows.UI.Xaml.Data.IValueConverter) (this.localResources.ContainsKey(key) ? this.localResources[key] : global::Windows.UI.Xaml.Application.Current.Resources[key]);
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::UITReader.ViewModels.FeedViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_IsInError(obj.IsInError, phase);
                        this.Update_SymbolAsChar(obj.SymbolAsChar, phase);
                        this.Update_Description(obj.Description, phase);
                        this.Update_Name(obj.Name, phase);
                        this.Update_IsSelectedInNavList(obj.IsSelectedInNavList, phase);
                    }
                }
            }
            private void Update_IsInError(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj3, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BooleanToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), null, null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj4, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BooleanToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "Reverse", null));
                }
            }
            private void Update_SymbolAsChar(global::System.Char obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_FontIcon_Glyph(this.obj4, obj.ToString(), null);
                }
            }
            private void Update_Description(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj4, obj, null);
                }
            }
            private void Update_Name(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj, null);
                }
            }
            private void Update_IsSelectedInNavList(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj6, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BooleanToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), null, null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj7, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BooleanToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "Reverse", null));
                }
            }

            private class AppShell_obj2_BindingsTracking
            {
                global::System.WeakReference<AppShell_obj2_Bindings> WeakRefToBindingObj; 

                public AppShell_obj2_BindingsTracking(AppShell_obj2_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<AppShell_obj2_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                }

                public void PropertyChanged_(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    AppShell_obj2_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::UITReader.ViewModels.FeedViewModel obj = sender as global::UITReader.ViewModels.FeedViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_IsInError(obj.IsInError, DATA_CHANGED);
                                    bindings.Update_SymbolAsChar(obj.SymbolAsChar, DATA_CHANGED);
                                    bindings.Update_Description(obj.Description, DATA_CHANGED);
                                    bindings.Update_Name(obj.Name, DATA_CHANGED);
                                    bindings.Update_IsSelectedInNavList(obj.IsSelectedInNavList, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "IsInError":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_IsInError(obj.IsInError, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "SymbolAsChar":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_SymbolAsChar(obj.SymbolAsChar, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Description":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_Description(obj.Description, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Name":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_Name(obj.Name, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "IsSelectedInNavList":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_IsSelectedInNavList(obj.IsSelectedInNavList, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void UpdateChildListeners_(global::UITReader.ViewModels.FeedViewModel obj)
                {
                    AppShell_obj2_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        if (bindings.dataRoot != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)bindings.dataRoot).PropertyChanged -= PropertyChanged_;
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_;
                        }
                    }
                }
            }
        }

        private class AppShell_obj8_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IAppShell_Bindings
        {
            private global::UITReader.NavMenuItem dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.FontIcon obj9;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;

            public AppShell_obj8_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 9:
                        this.obj9 = (global::Windows.UI.Xaml.Controls.FontIcon)target;
                        break;
                    case 10:
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::UITReader.NavMenuItem data = args.NewValue as global::UITReader.NavMenuItem;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::UITReader.NavMenuItem was expected.");
                 }
                 this.SetDataRoot(data);
                 this.Update();
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(args.Item as global::UITReader.NavMenuItem);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.Grid)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::UITReader.NavMenuItem) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
            }

            // IAppShell_Bindings

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

            // AppShell_obj8_Bindings

            public void SetDataRoot(global::UITReader.NavMenuItem newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::UITReader.NavMenuItem obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_SymbolAsChar(obj.SymbolAsChar, phase);
                        this.Update_Label(obj.Label, phase);
                    }
                }
            }
            private void Update_SymbolAsChar(global::System.Char obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_FontIcon_Glyph(this.obj9, obj.ToString(), null);
                }
            }
            private void Update_Label(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj9, obj, null);
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, obj, null);
                }
            }
        }

        private class AppShell_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IAppShell_Bindings
        {
            private global::UITReader.AppShell dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Primitives.ToggleButton obj13;
            private global::UITReader.Controls.NavMenuListView obj14;
            private global::UITReader.Controls.NavMenuListView obj16;

            private AppShell_obj1_BindingsTracking bindingsTracking;

            public AppShell_obj1_Bindings()
            {
                this.bindingsTracking = new AppShell_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 13:
                        this.obj13 = (global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)target;
                        ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)target).Unchecked += (global::System.Object param0, global::Windows.UI.Xaml.RoutedEventArgs param1) =>
                        {
                        this.dataRoot.CheckTogglePaneButtonSizeChanged();
                        };
                        break;
                    case 14:
                        this.obj14 = (global::UITReader.Controls.NavMenuListView)target;
                        break;
                    case 16:
                        this.obj16 = (global::UITReader.Controls.NavMenuListView)target;
                        break;
                    default:
                        break;
                }
            }

            // IAppShell_Bindings

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

            // AppShell_obj1_Bindings

            public void SetDataRoot(global::UITReader.AppShell newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }
            public void SetConverterLookupRoot(global::Windows.UI.Xaml.FrameworkElement rootElement)
            {
                this.converterLookupRoot = new global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement>(rootElement);
            }

            public global::Windows.UI.Xaml.Data.IValueConverter LookupConverter(string key)
            {
                if (this.localResources == null)
                {
                    global::Windows.UI.Xaml.FrameworkElement rootElement;
                    this.converterLookupRoot.TryGetTarget(out rootElement);
                    this.localResources = rootElement.Resources;
                    this.converterLookupRoot = null;
                }
                return (global::Windows.UI.Xaml.Data.IValueConverter) (this.localResources.ContainsKey(key) ? this.localResources[key] : global::Windows.UI.Xaml.Application.Current.Resources[key]);
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::UITReader.AppShell obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_NavList(obj.NavList, phase);
                    }
                }
            }
            private void Update_ViewModel(global::UITReader.ViewModels.MainViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_IsInDetailsMode(obj.IsInDetailsMode, phase);
                        this.Update_ViewModel_Feeds(obj.Feeds, phase);
                    }
                }
            }
            private void Update_ViewModel_IsInDetailsMode(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj13, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BooleanToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "Reverse", null));
                }
            }
            private void Update_ViewModel_Feeds(global::System.Collections.ObjectModel.ObservableCollection<global::UITReader.ViewModels.FeedViewModel> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj14, obj, null);
                }
            }
            private void Update_NavList(global::System.Collections.Generic.List<global::UITReader.NavMenuItem> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj16, obj, null);
                }
            }

            private class AppShell_obj1_BindingsTracking
            {
                global::System.WeakReference<AppShell_obj1_Bindings> WeakRefToBindingObj; 

                public AppShell_obj1_BindingsTracking(AppShell_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<AppShell_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    AppShell_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::UITReader.ViewModels.MainViewModel obj = sender as global::UITReader.ViewModels.MainViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_ViewModel_IsInDetailsMode(obj.IsInDetailsMode, DATA_CHANGED);
                                    bindings.Update_ViewModel_Feeds(obj.Feeds, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "IsInDetailsMode":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_IsInDetailsMode(obj.IsInDetailsMode, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Feeds":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Feeds(obj.Feeds, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::UITReader.ViewModels.MainViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::UITReader.ViewModels.MainViewModel obj)
                {
                    if (obj != cache_ViewModel)
                    {
                        if (cache_ViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                            cache_ViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
                        }
                    }
                }
                public void PropertyChanged_ViewModel_Feeds(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    AppShell_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::UITReader.ViewModels.FeedViewModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::UITReader.ViewModels.FeedViewModel>;
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
                public void CollectionChanged_ViewModel_Feeds(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    AppShell_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::UITReader.ViewModels.FeedViewModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::UITReader.ViewModels.FeedViewModel>;
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.Root = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 14 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)this.Root).SizeChanged += this.Root_SizeChanged;
                    #line 15 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)this.Root).KeyDown += this.AppShell_KeyDown;
                    #line default
                }
                break;
            case 11:
                {
                    this.LayoutRoot = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 12:
                {
                    this.RootSplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 13:
                {
                    this.TogglePaneButton = (global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target);
                    #line 179 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)this.TogglePaneButton).Checked += this.TogglePaneButton_Checked;
                    #line default
                }
                break;
            case 14:
                {
                    this.FeedsList = (global::UITReader.Controls.NavMenuListView)(target);
                    #line 134 "..\..\..\AppShell.xaml"
                    ((global::UITReader.Controls.NavMenuListView)this.FeedsList).ContainerContentChanging += this.FeedsListItemContainerContentChanging;
                    #line 135 "..\..\..\AppShell.xaml"
                    ((global::UITReader.Controls.NavMenuListView)this.FeedsList).SelectionChanged += this.FeedsList_SelectionChanged;
                    #line 136 "..\..\..\AppShell.xaml"
                    ((global::UITReader.Controls.NavMenuListView)this.FeedsList).ItemInvoked += this.FeedsList_ItemInvoked;
                    #line default
                }
                break;
            case 15:
                {
                    this.NavPaneDivider = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 16:
                {
                    this.NavMenuList = (global::UITReader.Controls.NavMenuListView)(target);
                    #line 146 "..\..\..\AppShell.xaml"
                    ((global::UITReader.Controls.NavMenuListView)this.NavMenuList).ContainerContentChanging += this.NavMenuItemContainerContentChanging;
                    #line 147 "..\..\..\AppShell.xaml"
                    ((global::UITReader.Controls.NavMenuListView)this.NavMenuList).ItemInvoked += this.NavMenuList_ItemInvoked;
                    #line default
                }
                break;
            case 17:
                {
                    this.AppShellFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                    #line 157 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Frame)this.AppShellFrame).Navigating += this.OnNavigatingToPage;
                    #line 157 "..\..\..\AppShell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Frame)this.AppShellFrame).Navigated += this.OnNavigatedToPage;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    AppShell_obj1_Bindings bindings = new AppShell_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    bindings.SetConverterLookupRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Grid element2 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    AppShell_obj2_Bindings bindings = new AppShell_obj2_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::UITReader.ViewModels.FeedViewModel) element2.DataContext);
                    bindings.SetConverterLookupRoot(this);
                    element2.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element2, bindings);
                }
                break;
            case 8:
                {
                    global::Windows.UI.Xaml.Controls.Grid element8 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    AppShell_obj8_Bindings bindings = new AppShell_obj8_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::UITReader.NavMenuItem) element8.DataContext);
                    element8.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element8, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}
