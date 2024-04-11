﻿using MauiApp1.Model;
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
    public class MainPageViewModel
    {
        private const int userId = 1;
        private readonly Service service;
        public ObservableCollection<ContactLastMessage> Contacts { get; private set; }

        public MainPageViewModel(Service service)
        {
            this.service = service;
            List<ContactLastMessage> contacts = service.GetContactLastMessages(userId, "");
            Contacts = new ObservableCollection<ContactLastMessage>(contacts);
        }

        public void FilterContacts(string searchText)
        {
            if (searchText == null)
            {
                searchText = "";
            }

            List<ContactLastMessage> contacts = service.GetContactLastMessages(userId, searchText);
            Contacts.Clear();
            foreach (var c in contacts)
            {
                Contacts.Add(c);
            }
        }
    }
}
