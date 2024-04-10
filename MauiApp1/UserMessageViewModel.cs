using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class UserMessageViewModel
    {
        public ObservableCollection<UserMessage> UserMessages { get; set; }

        public UserMessageViewModel()
        {
            UserMessages = new ObservableCollection<UserMessage>
            {
                new UserMessage("Razvan Uzum", "Salut frate", "Delivered", "razvan.png", "11:23"),
                new UserMessage("David Tripon", "Ce ma enerveaza materia asta", "Read", "david.png", "10:29"),
                new UserMessage("Teodora Vlad", "Imi place de Razvan", "New", "teo.png", "09:34"),
                new UserMessage("Dalia Utiu", "Azi am meci", "Waiting", "dalia.png", "09:12"),
                new UserMessage("Denisa Vince", "Ne uitam la cursa?", "Received", "deni.png", "08:59")
            };
        }
    }
}
