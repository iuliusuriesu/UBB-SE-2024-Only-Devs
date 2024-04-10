using MauiApp1.Model;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Repository repo = new Repository("Data/users.xml", "Data/chats.xml");

            this.BindingContext = new UserMessageViewModel();
        }
    }

}
