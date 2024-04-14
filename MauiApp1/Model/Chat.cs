using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Unmerged change from project 'MauiApp1 (net8.0-ios)'
Before:
using System.Xml;
After:
using System.Xml;
using MauiApp1.Model.Message;
using MauiApp1.Model.Message.Message;
using MauiApp1.Model.Message.Message.Message;
*/

/* Unmerged change from project 'MauiApp1 (net8.0-windows10.0.19041.0)'
Before:
using System.Xml;
After:
using System.Xml;
using MauiApp1.Model.Message;
using MauiApp1.Model.Message.Message;
*/

/* Unmerged change from project 'MauiApp1 (net8.0-maccatalyst)'
Before:
using System.Xml;
After:
using System.Xml;
using MauiApp1.Model.Message;
*/
using System.Xml;

/* Unmerged change from project 'MauiApp1 (net8.0-windows10.0.19041.0)'
Before:
using MauiApp1.Model.Message.Message.Message;
using MauiApp1.Model.Message.Message.Message.Message;
After:
using MauiApp1.Model.Message.Message;
using MauiApp1.Model.Message.Message.Message;
*/

/* Unmerged change from project 'MauiApp1 (net8.0-maccatalyst)'
Before:
using MauiApp1.Model.Message.Message.Message.Message;
After:
using MauiApp1.Model.Message.Message;
*/


namespace MauiApp1.Model
{
    public class Chat
    {

        public int chatId { get; private set; }
        public int senderId { get; private set; }
        public int receiverId { get; private set;  }

        private List<Message> messageList = new List<Message>();


        public Chat(int chatId, int senderId, int receiverId)
        {
            this.chatId = chatId;
            this.senderId = senderId;
            this.receiverId = receiverId;
        }

        public void addMessage(Message newMessage)
        {
            this.messageList.Add(newMessage);

        }

        public Message getLastMessage()
        {
            return this.messageList.Last();
        }

        public void setMessageList(List<Message> newMessageList)
        {
            this.messageList = newMessageList;
        }

        public List<Message> getAllMessages()
        {
            return this.messageList;
        }

    }

}
