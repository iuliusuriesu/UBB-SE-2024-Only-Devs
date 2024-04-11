using MauiApp1.Model;
using MauiApp1.ViewModel;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;

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

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string text = e.NewTextValue;
            viewModel.FilterContacts(text);
            this.BindingContext = viewModel;
        }
    }

}
