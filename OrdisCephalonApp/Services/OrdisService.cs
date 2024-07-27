using OrdisCephalonApp.Models;
using OrdisCephalonApp.Repositories;
using System;

namespace OrdisCephalonApp.Services
{
    public class OrdisService
    {
        private readonly IMessageRepository _messageRepository;

        public OrdisService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void Speak()
        {
            var messages = _messageRepository.GetAllMessages();
            var random = new Random();
            int index = random.Next(messages.Count());
            var message = messages.ElementAt(index);

            Console.WriteLine(message.Content);
        }

        public void AddMessage(string content)
        {
            var id = _messageRepository.GetAllMessages().Count() + 1;
            var message = new Message { Id = id, Content = content };
            _messageRepository.AddMessage(message);
            _messageRepository.Save();
        }
    }
}