using Entity;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        List<Message> GetMessages(int UserFrom, int UserTo);
        void UpdateMessage(Message message);
    }
}
