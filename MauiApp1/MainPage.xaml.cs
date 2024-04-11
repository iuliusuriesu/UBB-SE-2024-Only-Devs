using MauiApp1.Model;
using MauiApp1.ViewModel;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            this.BindingContext = viewModel;
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ChatPage));

            ((CollectionView)sender).SelectedItem = null;
        }

        public void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            string text = e.NewTextValue;
            viewModel.FilterContacts(text);
        }
    }

}
