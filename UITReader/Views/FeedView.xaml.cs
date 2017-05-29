
using UITReader.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace UITReader.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FeedView : Page
    {
        public MainViewModel ViewModel => AppShell.Current.ViewModel;

        public FeedView()
        {
            this.InitializeComponent();
            ViewModel.Initialized += (s, e) =>
            {
                // Realize the UI elements marked x:DeferLoadStrategy="Lazy". 
                // Deferred loading ensures that these elements do not appear 
                // in the UI before the feed data is available.
                FindName("FeedErrorMessage");
                FindName("FavoritesIsEmptyMessage");
            };
        }

        private void ArticlesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Raise PropertyChanged even if the clicked article is already current. This ensures 
            // that clicking an article in master-only view will always navigate to details-only view. 
            if (ViewModel.CurrentArticle.Equals(e.ClickedItem as ArticleViewModel))
            {
                ViewModel.OnPropertyChanged(nameof(ViewModel.CurrentArticle));
            }
        }

        private void ToggleButton_Toggled(object sender, RoutedEventArgs e)
        {
            var toggle = sender as ToggleButton;
            var article = toggle.DataContext as ArticleViewModel;

            if (toggle.IsChecked.Value) ViewModel.FavoritesFeed.Articles.Add(article);
            else
            {
                ViewModel.FavoritesFeed.Articles.Remove(article);

                // Save only for removals. Adds are automatically saved via 
                // CollectionChanged handler in MainViewModel.InitializeFeedsAsync.
                var withoutAwait = ViewModel.SaveFavoritesAsync();
            }
        }

        private async void RefreshFeed_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.CurrentFeed.RefreshAsync();
        }

        private void RemoveFeed_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveBadFeed();
        }
    }
}
