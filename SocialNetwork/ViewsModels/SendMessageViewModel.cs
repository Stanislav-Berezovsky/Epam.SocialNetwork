using Entity;
using System.Collections.Generic;

namespace SocialNetwork.ViewsModels
{
    public class SendMessageViewModel
    {
        public ProfileViewModel I { get; set; }
        public ProfileViewModel Companion { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}