using MauiApp1.Model;
using MauiApp1.ViewModel;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private Repository repo;
        private Service service;
        private Controller controller;
        private const int userId = 1;

        public MainPage()
        {
            string usersFilePath = "MauiApp1.Data.users.xml";
            string chatsFilePath = "MauiApp1.Data.chats.xml";
            repo = new Repository(usersFilePath, chatsFilePath);
            service = new Service(repo);
            controller = new Controller(service);

            InitializeComponent();

            controller.SetContactLastMessages(userId, "");
            this.BindingContext = controller.ContactLastMessages;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = e.NewTextValue;
            controller.SetContactLastMessages(userId, text);
            this.BindingContext = controller.ContactLastMessages;
        }
    }

}
