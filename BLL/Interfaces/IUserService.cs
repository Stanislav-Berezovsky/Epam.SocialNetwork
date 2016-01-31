using Entity;
using System.Collections.Generic;
using Common;
using Common.Paging;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        List<User> GetUsers();
        bool AddFriend(User user, int friendId);
        bool IsFriend(int userId, int friendId);
        IEnumerable<User> GetFriends(int key);
        PagedCollection<User> GetFriends(int key, PagingSettings settings);
        User GetUser(int key);
        IEnumerable<User> Search(string search);
        PagedCollection<User> Search( PagingSettings settings,string search= "");
        User GetUserByEmail(string email);
    }
}
