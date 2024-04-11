using MauiApp1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public class Controller
    {
        private Service service;

        public ObservableCollection<ContactLastMessage> ContactLastMessages { get; set; }

        public Controller(Service service)
        {
            this.service = service;
            ContactLastMessages = new ObservableCollection<ContactLastMessage>();
        }

        public void SetContactLastMessages(int userId, string name)
        {
            List<ContactLastMessage> list = service.GetContactLastMessages(userId, name);
            ContactLastMessages = new ObservableCollection<ContactLastMessage>(list);
        }
    }
}
