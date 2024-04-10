using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class ContactLastMessageViewModel
    {
        private Service service;
        private int userId;
        public ObservableCollection<ContactLastMessage> ContactLastMessages { get; }

        public ContactLastMessageViewModel(Service service, int userId)
        {
            this.service = service;
            this.userId = userId;
            ContactLastMessages = new ObservableCollection<ContactLastMessage>(service.ContactLastMessages(userId));
            /*ContactLastMessages = new ObservableCollection<ContactLastMessage>
            {
                new ContactLastMessage("Iulius Uriesu", "iulius.png", "Salut!", "13:45", "Sent")
            };*/
        }
    }
}
