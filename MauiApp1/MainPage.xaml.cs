using MauiApp1.Model;
using MauiApp1.ViewModel;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private Repository repo;
        private Service service;
        private const int userId = 1;

        public MainPage()
        {
            string usersFilePath = "MauiApp1.Data.users.xml";
            string chatsFilePath = "MauiApp1.Data.chats.xml";
            repo = new Repository(usersFilePath, chatsFilePath);
            service = new Service(repo);

            InitializeComponent();

            this.BindingContext = new ContactLastMessageViewModel(service, userId);
        }
    }

}
