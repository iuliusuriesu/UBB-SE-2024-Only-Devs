﻿using MauiApp1.ViewModel;
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

        private List<Chat> GetChatsSortedByLastMessageTimeStamp(int userId)
        {
            return repo.GetChatsByUser(userId).OrderByDescending(chat => chat.getLastMessage().GetTimestamp()).ToList();
        }

        private List<Chat> FilterChatsByName(int userId, string name)
        {
            List<Chat> chats = GetChatsSortedByLastMessageTimeStamp(userId);
            if (name.Length == 0)
            {
                return chats;
            }

            name = name.ToLower();

            List<Chat> matchingChats = new List<Chat>();
            foreach (Chat chat in chats)
            {
                User? u = repo.GetUser(chat.receiverId);
                if(u == null)
                {
                    continue;
                }

                string userName = u.name.ToLower();
                if (userName.Contains(name))
                {
                    matchingChats.Add(chat);
                }
            }

            return matchingChats;
        }

        public List<ContactLastMessage> GetContactLastMessages(int userId, string name)
        {
            List<ContactLastMessage> result = new List<ContactLastMessage>();

            List<Chat> chats = this.FilterChatsByName(userId, name);
            foreach (Chat chat in chats)
            {
                User? u = repo.GetUser(chat.receiverId);
                if (u == null)
                {
                    continue;
                }

                Message m = chat.getLastMessage();
                string msg = m.GetMessage();
                if (m.GetSenderId() == userId)
                {
                    msg = "You: " + msg;
                }
                if (msg.Length > 20)
                {
                    msg = msg.Substring(0, 17) + "...";
                }

                DateTime dt = m.GetTimestamp();
                string time = Utils.ToStringWithLeadingZero(dt.Day) + "." + Utils.ToStringWithLeadingZero(dt.Month) + "\n";
                time = time + Utils.ToStringWithLeadingZero(dt.Hour) + ":" + Utils.ToStringWithLeadingZero(dt.Minute);

                ContactLastMessage clm = new ContactLastMessage(u.name, u.profilePhotoPath, msg, time, m.GetStatus());
                result.Add(clm);
            }

            return result;
        }
    }
}
