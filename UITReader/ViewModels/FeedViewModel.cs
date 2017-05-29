
using UITReader.Common;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Controls;

namespace UITReader.ViewModels
{
    public class FeedViewModel : BindableBase
    {
        public FeedViewModel()
        {
            Articles = new ObservableCollection<ArticleViewModel>();
            Articles.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(IsEmpty));
                OnPropertyChanged(nameof(IsNotEmptyOrInError));
            };
        }

        private Uri _link;
        public Uri Link
        {
            get { return _link; }
            set
            {
                if (SetProperty(ref _link, value))
                {
                    OnPropertyChanged(nameof(LinkAsString));
                    var withoutAwait = this.RefreshAsync();
                }
            }
        }
        [IgnoreDataMember] public string LinkAsString
        {
            get { return Link?.ToString() ?? String.Empty; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) return;

                if (!value.Trim().StartsWith("http://") && !value.StartsWith("https://"))
                {
                    IsInError = true;
                    ErrorMessage = "Sorry. The URL must begin with http:// or https://";
                }
                else
                {
                    Uri uri = null;
                    if (Uri.TryCreate(value.Trim(), UriKind.Absolute, out uri)) Link = uri;
                }
            }
        }

        private string _name;
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }

        private string _description;
        public string Description { get { return _description; } set { SetProperty(ref _description, value); } }

        private Symbol _symbol;
        public Symbol Symbol
        {
            get { return _symbol; }
            set { if (SetProperty(ref _symbol, value)) OnPropertyChanged(nameof(SymbolAsChar)); }
        }
        public char SymbolAsChar => (char)Symbol;

        public ObservableCollection<ArticleViewModel> Articles { get; }
        public object ArticlesAsObject => Articles as object;
        public bool IsEmpty => Articles.Count == 0;
        public bool IsNotEmptyOrInError => !IsEmpty && !IsInError;
        public bool IsFavoritesFeed { get; set; }
        public bool IsNotFavoritesOrInError => !IsFavoritesFeed && !IsInError;

        [IgnoreDataMember] private bool _isSelectedInNavList;
        [IgnoreDataMember] public bool IsSelectedInNavList
        {
            get { return _isSelectedInNavList; }
            set { SetProperty(ref _isSelectedInNavList, value); }
        }

        [IgnoreDataMember] private bool _isLoading;
        [IgnoreDataMember] public bool IsLoading { get { return _isLoading; } set { SetProperty(ref _isLoading, value); } }

        [IgnoreDataMember] private bool _isInEdit;
        [IgnoreDataMember] public bool IsInEdit { get { return _isInEdit; } set { SetProperty(ref _isInEdit, value); } }

        [IgnoreDataMember] private bool _isInError;
        [IgnoreDataMember] public bool IsInError
        {
            get { return _isInError; }
            set
            {
                if (SetProperty(ref _isInError, value))
                {
                    OnPropertyChanged(nameof(IsNotEmptyOrInError));
                    OnPropertyChanged(nameof(IsNotFavoritesOrInError));
                }
            }
        }

        [IgnoreDataMember] public string _errorMessage;
        [IgnoreDataMember] public string ErrorMessage { get { return _errorMessage; } set { SetProperty(ref _errorMessage, value); } }

        public override bool Equals(object obj) => 
            obj is FeedViewModel ? (obj as FeedViewModel).GetHashCode() == GetHashCode() : false;
        public override int GetHashCode() => LinkAsString.GetHashCode();
    }
}
