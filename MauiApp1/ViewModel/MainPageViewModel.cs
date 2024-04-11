using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class MainPageViewModel
    {
        private const int userId = 1;
        private readonly Service service;

        private ObservableCollection<ContactLastMessage> _contacts;
        public ObservableCollection<ContactLastMessage> Contacts
        {
            get => _contacts;
            set
            {
                if (_contacts != value)
                {
                    _contacts = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (value != _searchText)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    FilterContacts(_searchText);
                }
            }
        }

        public MainPageViewModel(Service service)
        {
            this.service = service;
            List<ContactLastMessage> contacts = service.GetContactLastMessages(userId, "");
            Contacts = new ObservableCollection<ContactLastMessage>(contacts);
        }

        private void FilterContacts(string searchText)
        {
            if (searchText == null)
            {
                searchText = "";
            }

            List<ContactLastMessage> contacts = service.GetContactLastMessages(userId, searchText);
            Contacts = new ObservableCollection<ContactLastMessage>(contacts);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
