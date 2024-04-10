using MauiApp1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            foreach (Chat chat in repo.GetAllChats())
            {
                SortChatMessages(chat);
            }
        }

        public List<Chat> GetChatsSortedByLastMessageTimeStamp(int userId)
        {
            return repo.GetChatsByUser(userId).OrderByDescending(chat => chat.getLastMessage().GetTimestamp()).ToList();
        }

        public void SortChatMessages(Chat chat)
        {
            List<Message> sortedMessages = chat.getAllMessages().OrderBy(message => message.GetTimestamp()).ToList();
            chat.setMessageList(sortedMessages);
        }

        public List<ContactLastMessage> ContactLastMessages(int userId)
        {
            List<ContactLastMessage> result = new List<ContactLastMessage>();

            List<Chat> chats = this.GetChatsSortedByLastMessageTimeStamp(userId);
            foreach (Chat chat in chats)
            {
                User? u = repo.GetUser(userId);
                if (u == null)
                {
                    continue;
                }

                Message m = chat.getLastMessage();
                DateTime dt = m.GetTimestamp();
                ContactLastMessage clm = new ContactLastMessage(u.name, u.profilePhotoPath, m.GetMessage(), dt.ToString(), m.GetStatus());
                result.Add(clm);
            }

            return result;
        }
    }
}
