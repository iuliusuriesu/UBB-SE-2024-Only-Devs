using MauiApp1.Model;

namespace Lab3
{
    public class VideoMessage : Message
    {
        private readonly string videoPath;

        public VideoMessage(int messageId, int chatId, int senderId, DateTime timestamp, string status, string videoPath) : base(messageId, chatId, senderId, timestamp, status)
        {
            this.videoPath = videoPath;
        }

        public override string GetMessage()
        {
            return videoPath;
        }
    }
}
