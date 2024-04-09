using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public class ChatList
    {
        public int userId { get; set; }
        private List<Chat> chatList = new List<Chat>();

        public ChatList(int userId)
        {
            this.userId = userId;
        }
    }
}
