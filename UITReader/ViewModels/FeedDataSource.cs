
using UITReader.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Notifications;
using Windows.Web.Syndication;
using Windows.Data.Xml.Dom;
using Windows.UI.Xaml.Shapes;

namespace UITReader.ViewModels
{
    public static class FeedDataSource
    {
        /// <summary>
        /// Gets the initial set of feeds, either from local storage or 
        /// from the app package if there is nothing in local storage.
        /// </summary>
        public static async Task<List<FeedViewModel>> GetFeedsAsync()
        {
            var feeds = new List<FeedViewModel>();

            var favoritesFile = await ApplicationData.Current.LocalFolder.TryGetItemAsync("favorites.dat") as StorageFile;
            if (favoritesFile != null)
            {
                var buffer = await FileIO.ReadBufferAsync(favoritesFile);
                feeds.Add(Serializer.Deserialize<FeedViewModel>(buffer.ToArray()));
            }
            else
            {
                var feed = new FeedViewModel
                {
                    Name = "Favorites",
                    Description = "Articles that you've starred",
                    Symbol = Symbol.OutlineStar, 
                    Link = new Uri("http://localhost"),
                    IsFavoritesFeed = true
                };
                feeds.Add(feed);
            }

            var feedFile =
                await ApplicationData.Current.LocalFolder.TryGetItemAsync("feeds.dat") as StorageFile ??
                await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/feeds.dat"));
            if (feedFile != null)
            {
                var bytes = (await FileIO.ReadBufferAsync(feedFile)).ToArray();
                var feedData = Serializer.Deserialize<string[][]>(bytes);
                foreach (var feed in feedData) feeds.Add(new FeedViewModel { Name = feed[0], Link = new Uri(feed[1]) });
            }

            return feeds;
        }

        /// <summary>
        /// Retrieves feed data from the server and updates the appropriate FeedViewModel properties.
        /// </summary>
        public static async Task RefreshAsync(this FeedViewModel feedViewModel)
        {
            if (feedViewModel.Link.Host == "localhost" ||
                (feedViewModel.Link.Scheme != "http" && feedViewModel.Link.Scheme != "https")) return;

            feedViewModel.IsInError = false;
            feedViewModel.ErrorMessage = null;
            feedViewModel.IsLoading = true;
            feedViewModel.Symbol = Symbol.PostUpdate;
            Func<Task<bool>> tryGetFeed = async () =>
            { 
                try
                {
                    var feed = await new SyndicationClient().RetrieveFeedAsync(feedViewModel.Link);

                    feedViewModel.Name = String.IsNullOrEmpty(feedViewModel.Name) ? feed.Title.Text : feedViewModel.Name;
                    feedViewModel.Description = feed.Subtitle?.Text ?? String.Empty;

                    feed.Items.Select(item => new ArticleViewModel
                    {
                        Title = item.Title.Text,
                        Summary = item.Summary == null ? string.Empty :
                            item.Summary.Text.RegexRemove("\\&.{0,4}\\;").RegexRemove("<.*?>"),
                        Author = item.Authors.Select(a => a.NodeValue).FirstOrDefault(),
                        Link = item.ItemUri ?? item.Links.Select(l => l.Uri).FirstOrDefault(),
                        PublishedDate = item.PublishedDate
                    })
                    .ToList().ForEach(article =>
                    {
                        var favorites = AppShell.Current.ViewModel.FavoritesFeed;
                        var existingCopy = favorites.Articles.FirstOrDefault(a => a.Equals(article));
                        article = existingCopy ?? article;
                        if (!feedViewModel.Articles.Contains(article)) feedViewModel.Articles.Add(article);
                    });
                    return true;
                }
                catch (Exception)
                {
                    if (feedViewModel.Articles.Count == 0)
                    {
                        feedViewModel.IsInError = true;
                        feedViewModel.ErrorMessage = "Hmm... Are you sure this is an RSS URL?";
                    }
                    else
                    {
                        // TODO display error state that doesn't replace articles that have already been retrieved.
                    }
                    return false;
                }
            };

            int numberOfAttempts = 5;
            bool success = false;
            do { success = await tryGetFeed(); }
            while (!success && numberOfAttempts-- > 0);

            feedViewModel.IsLoading = false;
        }

        /// <summary>
        /// Saves the favorites feed (the first feed of the feeds list) to local storage. 
        /// </summary>
        public static async Task SaveFavoritesAsync(this IEnumerable<FeedViewModel> feeds)
        {
            var favorites = feeds.First();
            var file = await ApplicationData.Current.LocalFolder
                .CreateFileAsync("favorites.dat", CreationCollisionOption.ReplaceExisting);
            byte[] array = Serializer.Serialize(favorites);
            await FileIO.WriteBytesAsync(file, array);
        }

        /// <summary>
        /// Saves the feed data (not including the Favorites feed) to local storage. 
        /// </summary>
        public static async Task SaveAsync(this IEnumerable<FeedViewModel> feeds)
        {
            var file = await ApplicationData.Current.LocalFolder
                .CreateFileAsync("feeds.dat", CreationCollisionOption.ReplaceExisting);
            byte[] array = Serializer.Serialize(feeds.Skip(1).Select(feed => new[] { feed.Name, feed.Link.ToString() }).ToArray());
            await FileIO.WriteBytesAsync(file, array);
        }

        /// <summary>
        /// Show the toast
        /// </summary>
        private static void SendToast(this FeedViewModel feedViewModel)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText03;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(feedViewModel.Name));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode("Has a news!"));

            XmlNodeList toastImageElements = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastImageElements[0]).SetAttribute("src", "ms-appx:///Assets/StoreLogo.scale-200.png");

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            // Create the toast and attach event listeners
            ToastNotification toast = new ToastNotification(toastXml);

            // Show the toast. Be sure to specify the AppUserModelId on your application's shortcut!
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        /// <summary>
        /// Check Update Articles
        /// </summary>
        public static async Task UpdateArticles(this FeedViewModel feedViewModel)
        {
            var feed_old = new ArticleViewModel();
            feed_old.Title = feedViewModel.Articles.First().Title;
            feedViewModel.Articles.Clear();
            var feedFile =
                await ApplicationData.Current.LocalFolder.TryGetItemAsync("feeds.dat") as StorageFile ??
                await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/feeds.dat"));
            if (feedFile != null)
            {
                var bytes = (await FileIO.ReadBufferAsync(feedFile)).ToArray();
                var feedData = Serializer.Deserialize<string[][]>(bytes);
                foreach (var feed in feedData)
                {
                    feedViewModel.LinkAsString = feedViewModel.Name == feed[0] ? feed[1] : feedViewModel.LinkAsString;
                }
            }
            await RefreshAsync(feedViewModel);
            //
            if (!feed_old.Title.Equals(feedViewModel.Articles.First().Title))   SendToast(feedViewModel);
        }

    }
}
