﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class UserMessage
    {
        public string ContactName { get; }
        public string ContactProfilePhotoPath { get; }
        public string LastMessage { get; }
        public string LastMessageTime { get; }
        public string LastMessageStatus { get; }

        public UserMessage(string contactName, string contactProfilePhotoPath, string lastMessage, string lastMessageTime, string lastMessageStatus)
        {
            ContactName = contactName;
            ContactProfilePhotoPath = contactProfilePhotoPath;
            LastMessage = lastMessage;
            LastMessageTime = lastMessageTime;
            LastMessageStatus = lastMessageStatus;
        }
    }
}
