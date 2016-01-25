using Entity;
using System.Data.Entity;

namespace DAL
{
    public class SocialNetworkEntities : DbContext
    {

        public SocialNetworkEntities() : base("SocialNetworkEntities")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }




        public virtual void Commint()
        {
            base.SaveChanges();
        }

    }
}
