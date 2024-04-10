using MauiApp1.Model;

namespace Lab3
{
    public class TextMessage : Message
    {
        private readonly string text;

        public TextMessage(int messageId, int chatId, int senderId, DateTime timestamp, string status, string text) : base(messageId, chatId, senderId, timestamp, status)
        {
            this.text = text;
        }

        public override string GetMessage()
        {
            return text;
        }
    }
}
