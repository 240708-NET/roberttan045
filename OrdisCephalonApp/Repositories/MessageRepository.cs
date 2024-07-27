using OrdisCephalonApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrdisCephalonApp.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly List<Message> _messages;

        public MessageRepository()
        {
            _messages = new List<Message>
            {
                new Message { Id = 1, Content = "Hello, Operator! How can I assist you today?" },
                new Message { Id = 2, Content = "Everything is in order, Operator." },
                new Message { Id = 3, Content = "Ordis is happy to help, as always." }
            };
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return _messages;
        }

        public Message GetMessageById(int id)
        {
            return _messages.FirstOrDefault(m => m.Id == id);
        }

        public void AddMessage(Message message)
        {
            _messages.Add(message);
        }

        public void Save()
        {
            // Here we would normally save to a database or other storage
        }
    }
}