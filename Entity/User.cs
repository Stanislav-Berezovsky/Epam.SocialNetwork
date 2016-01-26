using System;
using System.Collections.Generic;

namespace Entity
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
            Photos = new HashSet<Photo>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime? UserBirthDate { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserPhotoId { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        public virtual ICollection<User> InFriends { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}