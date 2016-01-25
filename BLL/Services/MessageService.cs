using BLL.Interfaces;
using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork uow;
        private readonly IMessageRepository messageRepository;
        public MessageService(IUnitOfWork uow, IMessageRepository repository)
        {
            this.uow = uow;
            this.messageRepository = repository;
        }
        public void AddMessage(Message message)
        {
            messageRepository.AddMessage(message);
            uow.Commit();
        }

        public void DeleteMessage(Message message)
        {
            messageRepository.DeleteMessage(message);
            uow.Commit();
        }

        public List<Message> GetMessages(int UserFrom, int UserTo)
        {
            return messageRepository.GetMessages(UserFrom, UserTo);
        }

        public void UpdateMessage(Message message)
        {
            messageRepository.UpdateMessage(message);
        }
    }
}
