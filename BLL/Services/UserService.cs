using BLL.Interfaces;
using DAL.Interfaces;
using Entity;
using System.Collections.Generic;
using System;
using System.Linq;
using Common;
using Common.Paging;

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
            var user = GetUser(key);
            return user.Friends;
        }

        public PagedCollection<User> GetFriends(int key, PagingSettings settings)
        {
            var user = GetUser(key);
            var friendsTotalCount = user.Friends.Count();
            var friends = user.Friends.Skip((settings.CurrentPage - 1) * settings.EntitiesPerPage).Take(settings.EntitiesPerPage);
            settings.TotalCount = friendsTotalCount;
            return new PagedCollection<User>()
            {
                Settings = settings,
                Entities = friends            
            };
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

        public bool IsFriend(int userId, int friendId)
        {
            return GetFriends(userId).Any(u => u.UserId == friendId);
        }

        public IEnumerable<User> Search(string search)
        {
            var s = search ?? "";
            s = s.ToLower();
            return userRepository.GetMany(u => (u.UserName.ToLower() + " " + u.UserSurname.ToLower() + " " + u.UserEmail.ToLower() + " " + u.UserBirthDate.ToString().ToLower()).Contains(s));
        }

        public PagedCollection<User> Search(PagingSettings settings, string search = "")
        {
            var s = search ?? "";
            s = s.ToLower();
            var users = userRepository.GetMany(u => (u.UserName.ToLower() + " " + u.UserSurname.ToLower() + " " + u.UserEmail.ToLower() + " " + u.UserBirthDate.ToString().ToLower()).Contains(s));
            settings.TotalCount = users.Count();
            users = users.Skip((settings.CurrentPage - 1)*settings.EntitiesPerPage).Take(settings.EntitiesPerPage);

            return new PagedCollection<User>()
            {
                Settings = settings,
                Entities = users
            } ;
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
            uow.Commit();
        }
    }
}
