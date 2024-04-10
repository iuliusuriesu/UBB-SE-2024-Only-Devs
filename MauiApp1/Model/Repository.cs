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
        Dictionary<int, List<Chat>> chatsByUser;

        public Repository(string usersFilePath, string chatsFilePath)
        {
            allUsers = Utils.ReadUsersFromXml(usersFilePath);
            allChats = Utils.ReadChatsFromXml(chatsFilePath);

            chatsByUser = new Dictionary<int, List<Chat>>();
            foreach (User user in allUsers)
            {
                chatsByUser[user.userId] = assignChatsToUser(user.userId);
            }
        }

        private List<Chat> assignChatsToUser(int userId)
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

        public List<Chat> getChatsByUser(int userId)
        {
            return chatsByUser[userId];
        }
    }
}
