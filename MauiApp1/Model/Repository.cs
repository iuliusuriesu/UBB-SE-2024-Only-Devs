using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public class Repository
    {
        List<User> allUsers;
        List<Chat> allChats;
        Dictionary<int, List<Chat>> chatsByUser;

        public Repository()
        {
            allUsers = ReadUsers();
            allChats = ReadChats();

            chatsByUser = new Dictionary<int, List<Chat>>();
            foreach (User user in allUsers)
            {
                chatsByUser[user.userId] = assignChatsToUser(user.userId);
            }
        }

        private List<User> ReadUsers()
        {
            List<User> userList = new List<User>();

            return userList;
        }

        private List<Chat> ReadChats()
        {
            List<Chat> chatList = new List<Chat>();

            return chatList;
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
    }
}
