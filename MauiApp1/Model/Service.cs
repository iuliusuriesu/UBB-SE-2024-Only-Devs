using System;
using System.Collections.Generic;
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

        public List<Chat> chatsSortedByLastMessageTimeStamp(int userId)
        {
            List<Chat> result = repo.getChatsByUser(userId);

            return result;
        }
    }
}
