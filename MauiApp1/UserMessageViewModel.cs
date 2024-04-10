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
                new UserMessage("Razvan Uzum", "razvan.png", "Salut frate", "11:23", "Sent")
            };
        }
    }
}
