using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public class Service
    {
        private Repository repo;

        public Service(Repository repo)
        {
            this.repo = repo;
        }

        public List<Chat> GetUserChatsSortedByTimestamp(int userId)
        {
            return repo.getChatsByUser(userId).OrderByDescending(chat => chat.getLastMessage().GetTimestamp()).ToList();
        }

        public static List<Message> SortChatMessages(Chat chat)
        {
            List<Message> sortedMessages = chat.getAllMessages().OrderByDescending(message => message.GetTimestamp()).ToList();
            chat.setMessageList(sortedMessages);

            return sortedMessages;
        }
    }
}
