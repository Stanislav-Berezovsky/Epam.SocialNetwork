using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void AddUser(User user);

        void DeleteUser(User user);
        void UpdateUser(User user);

        User GetUser(int key);
        User GetUserByEmail(string email);

        IEnumerable<User> GetMany(Expression<Func<User, bool>> where);
    }
}
