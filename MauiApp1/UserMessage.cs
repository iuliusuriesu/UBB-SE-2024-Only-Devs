using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class UserMessage
    {
        public string Name {  get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string Time { get; set; }

        public UserMessage(string Name, string Message, string Status, string ProfilePhotoPath, string Time)
        {
            this.Name = Name;
            this.Message = Message;
            this.Status = Status;
            this.ProfilePhotoPath = ProfilePhotoPath;
            this.Time = Time;
        }
    }
}
