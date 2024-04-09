using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public class User
    {
        public int userId {  get; set; }
        public string name { get; set; }
        public string profilePhotoPath { get; set; }

        public User(int userId,  string name, string profilePhotoPath)
        {
            this.userId = userId;
            this.name = name;
            this.profilePhotoPath = profilePhotoPath;
        }
    }
}
