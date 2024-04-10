﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MauiApp1.Model
{
    public class Utils
    {
        public static List<User> ReadUsersFromXml(string filePath)
        {
            List<User> users = new List<User>();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    return users;
                }


                using (XmlTextReader reader = new XmlTextReader(filePath))
                {

                    while (reader.Read())
                    {

                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "User")
                        {

                            int userId = 0;
                            string name = "";
                            string profilePhotoPath = "";


                            while (reader.Read())
                            {

                                if (reader.NodeType == XmlNodeType.Element)
                                {

                                    switch (reader.Name)
                                    {
                                        case "UserID":
                                            userId = int.Parse(reader.ReadString());
                                            break;
                                        case "Name":
                                            name = reader.ReadString();
                                            break;
                                        case "ProfilePhotoPath":
                                            profilePhotoPath = reader.ReadString();
                                            break;
                                    }
                                }


                                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "User")
                                {

                                    users.Add(new User(userId, name, profilePhotoPath));
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading XML file: {ex.Message}");
            }

            return users;
        }

        public static void WriteUserToXml(User user, string filePath)
        {

            bool fileExists = File.Exists(filePath);


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;


            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {

                if (!fileExists)
                {

                    writer.WriteStartDocument();


                    writer.WriteStartElement("Users");
                }


                writer.WriteStartElement("User");


                writer.WriteElementString("UserID", user.userId.ToString());
                writer.WriteElementString("Name", user.name);
                writer.WriteElementString("ProfilePhotoPath", user.profilePhotoPath);


                writer.WriteEndElement();


                if (!fileExists)
                {

                    writer.WriteEndElement();


                    writer.WriteEndDocument();
                }
            }

            Console.WriteLine($"User data written to XML file: {filePath}");
        }

        public static void WriteUserToXmlAppending(User user, string filePath)
        {

            List<User> existingUsers = ReadUsersFromXml(filePath);


            existingUsers.Add(user);


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;


            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {

                writer.WriteStartDocument();
                writer.WriteStartElement("Users");


                foreach (User u in existingUsers)
                {
                    writer.WriteStartElement("User");
                    writer.WriteElementString("UserID", u.userId.ToString());
                    writer.WriteElementString("Name", u.name);
                    writer.WriteElementString("ProfilePhotoPath", u.profilePhotoPath);
                    writer.WriteEndElement();
                }


                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public static List<Chat> ReadChatsFromXml(string filePath)
        {
            List<Chat> chats = new List<Chat>();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    return chats;
                }

                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Chat")
                        {
                            int chatId = 0;
                            int senderId = 0;
                            int receiverId = 0;
                            List<Message> messages = new List<Message>();


                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    switch (reader.Name)
                                    {
                                        case "ChatId":
                                            chatId = int.Parse(reader.ReadElementContentAsString());
                                            break;
                                        case "SenderId":
                                            senderId = int.Parse(reader.ReadElementContentAsString());
                                            break;
                                        case "ReceiverId":
                                            receiverId = int.Parse(reader.ReadElementContentAsString());
                                            break;
                                        case "Messages":
                                            // Read messages within the chat
                                            messages = ReadMessages(reader);
                                            break;
                                    }
                                }

                                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Chat")
                                {
                                    Chat c1 = new Chat(chatId, senderId, receiverId);
                                    c1.setMessageList(messages);
                                    chats.Add(c1);

                                    Chat c2 = new Chat(chatId, receiverId, senderId);
                                    c2.setMessageList(messages);
                                    chats.Add(c2);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading XML file: {ex.Message}");
            }

            return chats;
        }

        private static List<Message> ReadMessages(XmlReader reader)
        {
            List<Message> messages = new List<Message>();

            if (reader.ReadToDescendant("Message"))
            {
                do
                {
                    int messageId = 0, chatId = 0, senderId = 0;
                    DateTime timestamp = DateTime.MinValue;
                    string content = "", status = "", type = ""; // Added type field

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.Name)
                            {
                                case "MessageId":
                                    messageId = int.Parse(reader.ReadElementContentAsString());
                                    break;
                                case "ChatId":
                                    chatId = int.Parse(reader.ReadElementContentAsString());
                                    break;
                                case "SenderId":
                                    senderId = int.Parse(reader.ReadElementContentAsString());
                                    break;
                                case "Timestamp":
                                    timestamp = DateTime.Parse(reader.ReadElementContentAsString());
                                    break;
                                case "Content":
                                    content = reader.ReadElementContentAsString();
                                    break;
                                case "Status":
                                    status = reader.ReadElementContentAsString();
                                    break;
                                case "Type":
                                    type = reader.ReadElementContentAsString(); // Read the type field
                                    break;
                            }
                        }

                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Message")
                        {
                            //messages.Add(new Message(messageId, chatId, senderId, timestamp, content, status, type)); // Pass type to Message constructor
                            //break;

                            Message message;
                            switch (type)
                            {
                                case "voice":
                                    message = new VoiceMessage(messageId, chatId, senderId, timestamp, status, content);
                                    break;
                                case "text":
                                    message = new TextMessage(messageId, chatId, senderId, timestamp, status, content);
                                    break;
                                case "photo":
                                    message = new PhotoMessage(messageId, chatId, senderId, timestamp, status, content);
                                    break;
                                case "video":
                                    message = new VideoMessage(messageId, chatId, senderId, timestamp, status, content);
                                    break;
                                case "file":
                                    message = new FileMessage(messageId, chatId, senderId, timestamp, status, content);
                                    break;

                                default:
                                    // message = new Message(messageId, chatId, senderId, timestamp, status, content);
                                    message = new TextMessage(messageId, chatId, senderId, timestamp, status, content);

                                    break;
                            }
                            messages.Add(message);
                            break;


                        }
                    }
                } while (reader.ReadToNextSibling("Message"));
            }

            return messages;
        }

        public static void WriteChatToXmlAppending(Chat chat, string filePath)
        {
            List<Chat> existingChats = ReadChatsFromXml(filePath);
            existingChats.Add(chat);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Chats");

                foreach (Chat c in existingChats)
                {
                    writer.WriteStartElement("Chat");
                    writer.WriteElementString("ChatId", c.chatId.ToString());
                    writer.WriteElementString("SenderId", c.senderId.ToString());
                    writer.WriteElementString("ReceiverId", c.receiverId.ToString());

                    writer.WriteStartElement("Messages");

                    foreach (Message m in c.getAllMessages())
                    {
                        writer.WriteStartElement("Message");
                        writer.WriteElementString("MessageId", m.GetMessageId().ToString());
                        writer.WriteElementString("ChatId", m.GetChatId().ToString());
                        writer.WriteElementString("SenderId", m.GetSenderId().ToString());
                        writer.WriteElementString("Timestamp", m.GetTimestamp().ToString());
                        writer.WriteElementString("Content", m.GetMessage());
                        writer.WriteElementString("Status", m.GetStatus());

                        if (m.GetType() == typeof(TextMessage))
                        {
                            writer.WriteElementString("Type", "text");
                        }

                        if (m.GetType() == typeof(VideoMessage))
                        {
                            writer.WriteElementString("Type", "video");
                        }
                        else

                        if (m.GetType() == typeof(VoiceMessage))
                        {
                            writer.WriteElementString("Type", "voice");
                        }

                        else

                        if (m.GetType() == typeof(PhotoMessage))
                        {
                            writer.WriteElementString("Type", "photo");
                        }
                        else
                        {
                            writer.WriteElementString("Type", "message");
                        }

                        //writer.WriteElementString("Type", m.Type);
                        writer.WriteEndElement(); // Message
                    }

                    writer.WriteEndElement(); // Messages
                    writer.WriteEndElement(); // Chat
                }

                writer.WriteEndElement(); // Chats
                writer.WriteEndDocument();
            }

            Console.WriteLine($"Chat data appended to XML file: {filePath}");
        }
    }
}
