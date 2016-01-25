using BLL.Interfaces;
using DAL.Interfaces;
using Entity;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }

        public bool AddFriend(User user, int friendId)
        {
            var friend = GetUser(friendId);
            if (friend == null)
                return false;
            if (user.Friends.Contains(friend))
                return false;
            user.Friends.Add(friend);
            friend.Friends.Add(user);
            uow.Commit();
            return true;
        }

        public void AddUser(User user)
        {
            userRepository.AddUser(user);
            uow.Commit();
        }

        public void DeleteUser(User user)
        {
            userRepository.DeleteUser(user);
            uow.Commit();
        }

        public IEnumerable<User> GetFriends(int key)
        {
            return GetUser(key).Friends;
        }

        public User GetUser(int key)
        {
            return userRepository.GetUser(key);
        }

        public User GetUserByEmail(string email)
        {
            return userRepository.GetUserByEmail(email);
        }

        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public IEnumerable<User> Search(string search)
        {
            var s = search.ToLower();
            return userRepository.GetMany(u => (u.UserName.ToLower() + " " + u.UserSurname.ToLower() + " " + u.UserEmail.ToLower() + " " + u.UserBirthDate.ToString().ToLower()).Contains(s));
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
            uow.Commit();
        }
    }
}
