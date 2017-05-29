﻿

using UITReader.Controls;
using UITReader.ViewModels;
using UITReader.Views;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System;

namespace UITReader
{
    /// <summary>
    /// The "chrome" layer of the app that provides top-level navigation with
    /// proper keyboarding navigation.
    /// </summary>
    public sealed partial class AppShell : Page
    {
        public static AppShell Current = null;

        public MainViewModel ViewModel { get; } = new MainViewModel();

        public List<NavMenuItem> NavList { get; } = new List<NavMenuItem>(new[] 
        {
            new NavMenuItem()
            {
                Symbol = Symbol.Add,
                Label = "Add feed",
                DestPage = typeof(MasterDetailPage),
                Arguments = typeof(AddFeedView)
            },
            new NavMenuItem()
            {
                Symbol = Symbol.Edit,
                Label = "Edit feeds",
                DestPage = typeof(MasterDetailPage),
                Arguments = typeof(EditFeedsView)
            }
        });

        /// <summary>
        /// Initializes a new instance of the AppShell, sets the static 'Current' reference,
        /// adds callbacks for Back requests and changes in the SplitView's DisplayMode, and
        /// provide the nav menu list with the data to display.
        /// </summary>
        public AppShell()
        {
            this.InitializeComponent();
            Current = this;

            this.Loaded += async (sender, args) =>
            {
                await ViewModel.InitializeFeedsAsync();
                FeedsList.SelectedIndex = FeedsList.Items.Count > 1 ? 1 : 0;
                
                var titleBar = Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar;
            };
            StartTimers();
            ViewModel.BadFeedRemoved += (s, e) => FeedsList.SelectedItem = ViewModel.CurrentFeed;
        }

        public Frame AppFrame => AppShellFrame;

        /// <summary>
        /// Default keyboard focus movement for any unhandled keyboarding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppShell_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            FocusNavigationDirection direction = FocusNavigationDirection.None;
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Left:
                case Windows.System.VirtualKey.GamepadDPadLeft:
                case Windows.System.VirtualKey.GamepadLeftThumbstickLeft:
                case Windows.System.VirtualKey.NavigationLeft:
                    direction = FocusNavigationDirection.Left;
                    break;
                case Windows.System.VirtualKey.Right:
                case Windows.System.VirtualKey.GamepadDPadRight:
                case Windows.System.VirtualKey.GamepadLeftThumbstickRight:
                case Windows.System.VirtualKey.NavigationRight:
                    direction = FocusNavigationDirection.Right;
                    break;

                case Windows.System.VirtualKey.Up:
                case Windows.System.VirtualKey.GamepadDPadUp:
                case Windows.System.VirtualKey.GamepadLeftThumbstickUp:
                case Windows.System.VirtualKey.NavigationUp:
                    direction = FocusNavigationDirection.Up;
                    break;

                case Windows.System.VirtualKey.Down:
                case Windows.System.VirtualKey.GamepadDPadDown:
                case Windows.System.VirtualKey.GamepadLeftThumbstickDown:
                case Windows.System.VirtualKey.NavigationDown:
                    direction = FocusNavigationDirection.Down;
                    break;
            }

            if (direction != FocusNavigationDirection.None)
            {
                var control = FocusManager.FindNextFocusableElement(direction) as Control;
                if (control != null)
                {
                    control.Focus(FocusState.Programmatic);
                    e.Handled = true;
                }
            }
        }

        public void OpenNavePane()
        {
            TogglePaneButton.IsChecked = true;
        }

        #region BackRequested Handlers

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            bool handled = e.Handled;
            this.BackRequested(ref handled);
            e.Handled = handled;
        }

        private void BackRequested(ref bool handled)
        {
            // Get a hold of the current frame so that we can inspect the app back stack.

            if (this.AppFrame == null)
                return;

            // Check to see if this is the top-most page on the app back stack.
            if (this.AppFrame.CanGoBack && !handled)
            {
                // If not, set the event to handled and go back to the previous page in the app.
                handled = true;
                this.AppFrame.GoBack();
            }
        }

        #endregion

        #region Navigation

        /// <summary>
        /// Navigate to the Page for the selected <paramref name="listViewItem"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="listViewItem"></param>
        private void NavMenuList_ItemInvoked(object sender, ListViewItem listViewItem)
        {
            FeedsList.SelectedIndex = -1;

            var item = (NavMenuItem)((NavMenuListView)sender).ItemFromContainer(listViewItem);

            if (item != null)
            {
                AppFrame.Navigate(typeof(MasterDetailPage), item.Arguments);
            }
        }

        /// <summary>
        /// Navigate to the Page for the selected <paramref name="listViewItem"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="listViewItem"></param>
        private void FeedsList_ItemInvoked(object sender, ListViewItem listViewItem)
        {
            NavMenuList.SelectedIndex = -1;

            var item = (FeedViewModel)((NavMenuListView)sender).ItemFromContainer(listViewItem);

            if (item != null)
            {
                AppFrame.Navigate(typeof(MasterDetailPage), item.Link);
            }
        }

        /// <summary>
        /// Update the FeedViewModel.IsSelectedInNavList state when the selection changes in the UI. 
        /// </summary>
        private void FeedsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1) (e.AddedItems[0] as FeedViewModel).IsSelectedInNavList = true;
            if (e.RemovedItems.Count == 1) (e.RemovedItems[0] as FeedViewModel).IsSelectedInNavList = false;
        }

        public void NavigateToCurrentFeed()
        {
            FeedsList.SelectedItem = ViewModel.CurrentFeed;
            NavMenuList.SelectedIndex = -1;
            AppShell.Current.AppFrame.Navigate(typeof(MasterDetailPage), ViewModel.CurrentFeed.Link);
        }

        public void NavigateToAddFeedView()
        {
            NavMenuList.SelectedIndex = 0;
            AppFrame.Navigate(typeof(MasterDetailPage), typeof(AddFeedView));
        }

        /// <summary>
        /// Ensures the nav menu reflects reality when navigation is triggered outside of
        /// the nav menu buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
        }

        private void OnNavigatedToPage(object sender, NavigationEventArgs e)
        {
            // After a successful navigation set keyboard focus to the loaded page
            if (e.Content is Page && e.Content != null)
            {
                var control = (Page)e.Content;
                control.Loaded += Page_Loaded;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ((Page)sender).Focus(FocusState.Programmatic);
            ((Page)sender).Loaded -= Page_Loaded;
        }

        #endregion

        public Rect TogglePaneButtonRect { get; private set; }

        /// <summary>
        /// An event to notify listeners when the hamburger button may occlude other content in the app.
        /// The custom "PageHeader" user control is using this.
        /// </summary>
        public event TypedEventHandler<AppShell, Rect> TogglePaneButtonRectChanged;

        /// <summary>
        /// Check for the conditions where the navigation pane does not occupy the space under the floating
        /// hamburger button and trigger the event.
        /// </summary>
        private void CheckTogglePaneButtonSizeChanged()
        {
            TogglePaneButtonRect =
                RootSplitView.DisplayMode == SplitViewDisplayMode.Inline ||
                RootSplitView.DisplayMode == SplitViewDisplayMode.Overlay 
                    ? TogglePaneButton.TransformToVisual(this).TransformBounds(
                        new Rect(0, 0, TogglePaneButton.ActualWidth, TogglePaneButton.ActualHeight))
                    : new Rect();
            TogglePaneButtonRectChanged?.Invoke(this, this.TogglePaneButtonRect);
        }

        private void Root_SizeChanged(object sender, SizeChangedEventArgs e) => CheckTogglePaneButtonSizeChanged();

        /// <summary>
        /// Enable accessibility on each nav menu item by setting the AutomationProperties.Name on each container
        /// using the associated Label of each item.
        /// </summary>
        private void UpdateAutomationName<T>(ContainerContentChangingEventArgs args, string value)
        {
            if (!args.InRecycleQueue && args.Item != null && args.Item is T)
            {
                args.ItemContainer.SetValue(AutomationProperties.NameProperty, value);
            }
            else
            {
                args.ItemContainer.ClearValue(AutomationProperties.NameProperty);
            }
        }

        /// <summary>
        /// Enable accessibility on each nav menu item by setting the AutomationProperties.Name on each container
        /// using the associated Label of each item.
        /// </summary>
        private void NavMenuItemContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args) =>
            UpdateAutomationName<NavMenuItem>(args, ((NavMenuItem)args.Item).Label);

        /// <summary>
        /// Enable accessibility on each nav menu item by setting the AutomationProperties.Name on each container
        /// using the associated Label of each item.
        /// </summary>
        private void FeedsListItemContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args) =>
            UpdateAutomationName<FeedViewModel>(args, ((FeedViewModel)args.Item).Name);

        private void TogglePaneButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        DispatcherTimer dispatcherTimer;
        public void StartTimers()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }

        // callback runs on UI thread
        private async void dispatcherTimer_Tick(object sender, object e)
        {
            // execute repeating task here
            await ViewModel.UpdateFeedAsync();
        }
    }
}
