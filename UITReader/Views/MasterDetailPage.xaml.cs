
using UITReader.Common;
using UITReader.ViewModels;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;

namespace UITReader.Views
{
    public sealed partial class MasterDetailPage : Page
    {
        private MainViewModel ViewModel => AppShell.Current.ViewModel;
        private bool isCurrentFeedNew = false;
        DataTransferManager dataTranferManager = DataTransferManager.GetForCurrentView();

        public MasterDetailPage()
        {
            InitializeComponent();

            ViewModel.PropertyChanged += ViewModel_PropertyChanged; 

            ArticleWebView.NavigationStarting += async (s, e) =>
            {
                if (!await ViewModel.CurrentArticle.Link.LaunchBrowserForNonMatchingUriAsync(e))
                {
                    // In-app navigation, so hide the WebView control and display the progress 
                    // animation until the page load is completed.
                    ArticleWebView.Visibility = Visibility.Collapsed;
                    button.Visibility = Visibility.Collapsed;
                    LoadingProgressBar.Visibility = Visibility.Visible;
                }
            };

            ArticleWebView.LoadCompleted += (s, e) =>
            {
                ArticleWebView.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Visible;
                LoadingProgressBar.Visibility = Visibility.Collapsed;
            };
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Set a flag so that, in narrow mode, details-only navigation doesn't occur if 
            // the CurrentArticle is changed solely as a side-effect of changing the CurrentFeed.
            if (e.PropertyName == nameof(ViewModel.CurrentFeed)) isCurrentFeedNew = true;
            else if (e.PropertyName == nameof(ViewModel.CurrentArticle))
            {
                if (ViewModel.CurrentArticle != null)
                {
                    ArticleWebView.Navigate(ViewModel.CurrentArticle.Link);
                }
                else
                {
                    ArticleWebView.NavigateToString(string.Empty);
                }

                if (AdaptiveStates.CurrentState == NarrowState)
                {
                    bool switchToDetailsView = !isCurrentFeedNew;
                    isCurrentFeedNew = false;
                    if (switchToDetailsView)
                    {
                        // Use "drill in" transition for navigating from master list to detail view
                        Frame.Navigate(typeof(DetailPage), null, new DrillInNavigationTransitionInfo());
                    }
                }
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            dataTranferManager.DataRequested += DataTransferManager_DataRequested;
            if (e.Parameter is Uri || e.Parameter == null || 
                (e.Parameter is string && String.IsNullOrEmpty(e.Parameter as string)))
            {
                if (MasterFrame.CurrentSourcePageType != typeof(FeedView))
                {
                    MasterFrame.Navigate(typeof(FeedView));
                }

                var feedUri = e.Parameter as Uri;
                if (feedUri != null)
                {
                    var feed = ViewModel.Feeds.FirstOrDefault(f => f.Link == feedUri);
                    ViewModel.CurrentFeed = feed;
                    await feed.RefreshAsync();
                }
            }
            else
            {
                var viewType = e.Parameter as Type;

                if (viewType != null && MasterFrame.CurrentSourcePageType != viewType)
                {
                    MasterFrame.Navigate(viewType);
                }

                UpdateForVisualState(AdaptiveStates.CurrentState);
            }
        }
        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest request = args.Request;
            request.Data.Properties.Title = "Share to your friend";
            request.Data.SetText("Share to be shared");
            request.Data.SetWebLink(ViewModel.CurrentArticle.Link);

        }
        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }

        private void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {
            var isNarrow = newState == NarrowState;

            if (isNarrow && oldState == DefaultState)
            {
                // Resize down to the detail item. Don't play a transition.
                Frame.Navigate(typeof(DetailPage), null, new SuppressNavigationTransitionInfo());
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }
    }
}
