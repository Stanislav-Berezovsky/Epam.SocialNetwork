using Entity;
using System;
using System.Collections.Generic;

namespace SocialNetwork.ViewsModels
{
    public class ProfileViewModel
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime? UserBirthDate { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoto { get; set; }
        public bool IsFriend { get; set; }
        public IEnumerable<User> Friends { get; set; }
        public IEnumerable<Photo> Photos { get; set; }

        public IEnumerable<Message> Messages { get; set; }


        public string DisplayName => UserName + " " + UserSurname;
    }
}