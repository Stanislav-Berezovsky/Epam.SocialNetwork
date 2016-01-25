using Entity;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        List<User> GetUsers();
        bool AddFriend(User user, int friendId);
        IEnumerable<User> GetFriends(int key);
        User GetUser(int key);
        IEnumerable<User> Search(string search);
        User GetUserByEmail(string email);
    }
}
