using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public class Chat
    {
        public int chatId {  get; set; }
        public int senderId {  get; set; }
        public int receiverId {  get; set; }
        private List<Message> messages = new List<Message>();

        public Chat(int chatId,  int senderId, int receiverId)
        {
            this.chatId = chatId;
            this.senderId = senderId;
            this.receiverId = receiverId;
        }
    }
}
