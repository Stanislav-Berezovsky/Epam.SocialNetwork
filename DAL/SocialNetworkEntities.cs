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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(c => c.Friends)
                .WithMany(p => p.InFriends)
                .Map(m =>
                {
            // Ссылка на промежуточную таблицу
            m.ToTable("Friends");

            // Настройка внешних ключей промежуточной таблицы
                    m.MapLeftKey("User1Id");
                    m.MapRightKey("User2Id");
                });
        }
    }
}
