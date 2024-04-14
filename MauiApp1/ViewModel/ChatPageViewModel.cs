using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class ChatPageViewModel : INotifyPropertyChanged
    {
        private readonly Service service;
        private int chatId;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _contactName;
        public string ContactName
        {
            get => _contactName;
            private set
            {
                if (_contactName != value)
                {
                    _contactName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _contactProfilePhotoPath;
        public string ContactProfilePhotoPath
        {
            get => _contactProfilePhotoPath;
            private set
            {
                if (value != _contactProfilePhotoPath)
                {
                    _contactProfilePhotoPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> Messages { get; private set; }

        public ChatPageViewModel(Service service)
        {
            this.service = service;
            Messages = new ObservableCollection<string>();
        }

        public void SetChatId(int chatId)
        {
            this.chatId = chatId;
            ContactName = service.GetContactName(chatId);
            ContactProfilePhotoPath = service.GetContactProfilePhotoPath(chatId);

            List<string> messages = service.GetChatMessages(chatId);
            Messages.Clear();
            foreach (string m in messages)
            {
                Messages.Add(m);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
