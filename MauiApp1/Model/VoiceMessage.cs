﻿using MauiApp1.Model;

namespace Lab3
{
    public class VoiceMessage : Message
    {
        private readonly string voiceNotePath; 

        public VoiceMessage(int messageId, int chatId, int senderId, DateTime timestamp, string status, string voiceNotePath) : base(messageId, chatId, senderId, timestamp, status)
        {
            this.voiceNotePath = voiceNotePath;
        }

        public override string GetMessage()
        {
            return voiceNotePath;
        }
    }
}