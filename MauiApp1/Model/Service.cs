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
        }

        public List<Chat> GetChatsSortedByLastMessageTimeStamp(int userId)
        {
            List<Chat> result = repo.GetChatsByUser(userId);

            return result;
        }

        public void SortChatMessages(Chat chat)
        {

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
