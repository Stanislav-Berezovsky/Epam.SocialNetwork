using Entity;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL
{
    public class BaseInisializze : DropCreateDatabaseIfModelChanges<SocialNetworkEntities>
    {
        protected override void Seed(SocialNetworkEntities context)
        {

            new List<Role>()
            {
                new Role() {RoleName = "admin" },
                new Role() {RoleName = "user" }
            }.ForEach(r => context.Roles.Add(r));

            context.Commint();
        }
    }
}
