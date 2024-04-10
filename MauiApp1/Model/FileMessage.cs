﻿using MauiApp1.Model;

namespace Lab3
{
    public class FileMessage : Message
    {
        private readonly string filePath;

        public FileMessage(int messageId, int chatId, int senderId, DateTime timestamp, string status, string filePath) : base(messageId, chatId, senderId, timestamp, status)
        {
            this.filePath = filePath;
        }

        public override string GetMessage()
        {
            return filePath;
        }
    }
}
