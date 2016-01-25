using System.Collections.Generic;

namespace SocialNetwork.ViewsModels
{
    public class FriendsViewModel
    {
        public IEnumerable<ProfileViewModel> Users { get; set; }
        public bool IsFriends { get; set; }
    }
}