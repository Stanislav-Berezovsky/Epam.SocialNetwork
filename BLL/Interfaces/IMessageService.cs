using Entity;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IMessageService
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        List<Message> GetMessages(int UserFrom, int UserTo);
        void UpdateMessage(Message message);
    }
}
