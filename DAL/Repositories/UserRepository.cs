using DAL.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(IUnitOfWork uow)
        {
            this.context = uow.GetContext();
        }
        public List<User> GetUsers()
        {
            return context.Set<User>().ToList();
        }

        public void AddUser(User user)
        {
            context.Set<User>().Add(user);
        }

        public void UpdateUser(User user)
        {
            // context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            var oldUser = GetUser(user.UserId);
            context.Entry(oldUser).CurrentValues.SetValues(user);
        }
        public User GetUserByEmail(string email)
        {
            return context.Set<User>().Where(u => u.UserEmail == email).FirstOrDefault();           
        }

        public void DeleteUser(User user)
        {
            context.Set<User>().Remove(user);
        }

        public User GetUser(int key)
        {
            return context.Set<User>().Find(key);
        }

        public IEnumerable<User> GetMany(Expression<Func<User, bool>> where)
        {
            return context.Set<User>().Where(where);
        }

    }
}
