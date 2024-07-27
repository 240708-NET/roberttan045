using OrdisCephalonApp.Models;
using System.Collections.Generic;

namespace OrdisCephalonApp.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAllMessages();
        Message GetMessageById(int id);
        void AddMessage(Message message);
        void Save();
    }
}