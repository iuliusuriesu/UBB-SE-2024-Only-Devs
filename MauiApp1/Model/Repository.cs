using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MauiApp1.Model
{
    public class Repository
    {
        List<User> allUsers;
        List<Chat> allChats;

        public Repository(string usersFilePath, string chatsFilePath)
        {
            allUsers = Utils.ReadUsersFromXml(usersFilePath);
            allChats = Utils.ReadChatsFromXml(chatsFilePath);
        }

        public List<Chat> GetChatsByUser(int userId)
        {
            List<Chat> chats = new List<Chat>();
            foreach (Chat chat in allChats)
            {
                if (chat.senderId == userId)
                {
                    chats.Add(chat);
                }
            }

            return chats;
        }

        public User? GetUser(int userId)
        {
            return allUsers.Find(user => user.userId == userId);
        }

        public List<Chat> GetAllChats()
        {
            return allChats;
        }
    }
}
