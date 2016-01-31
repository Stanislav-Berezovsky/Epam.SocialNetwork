using System.Collections.Generic;
using Common;

namespace SocialNetwork.ViewsModels
{
    public class FriendsViewModel
    {
        public FriendsViewModel()
        {
            this.Users = new PagedCollection<ProfileViewModel>();
        }

        public int id { get; set; }
        public string Search { get; set; }
        public PagedCollection<ProfileViewModel> Users { get; set; }
        public bool IsFriends { get; set; }
    }
}