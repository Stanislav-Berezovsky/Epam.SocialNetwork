using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DbContext context;

        public MessageRepository(DbContext dbC)
        {
            this.context = dbC;
        }
        public void AddMessage(Message message)
        {
            context.Set<Message>().Add(message);
        }

        public void DeleteMessage(Message message)
        {
            context.Set<Message>().Remove(message);
        }

        public List<Message> GetMessages(int UserFrom, int UserTo)
        {
            return context.Set<Message>().Where(m => (m.UserFrom.UserId == UserFrom && m.UserTo.UserId == UserTo)
            || m.UserFrom.UserId == UserTo && m.UserTo.UserId == UserFrom).OrderBy(m => m.Date).ToList();
        }

        public void UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
