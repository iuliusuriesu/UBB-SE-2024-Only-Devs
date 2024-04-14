﻿using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate IncomingTemplate { get; set; }
        public DataTemplate OutgoingTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (!(item is MessageModel message))
            {
                return null;
            }

            return message.incoming ? IncomingTemplate : OutgoingTemplate;
        }
    }
}
