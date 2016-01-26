using DAL.Interfaces;
using Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(IUnitOfWork uow)
        {
            this.context = uow.GetContext();
        }
        public void AddRole(Role role)
        {
            context.Set<Role>().Add(role);
        }

        public void DeleteRole(Role role)
        {
            context.Set<Role>().Remove(role);
        }

        public Role GetRoleById(int key)
        {
            return context.Set<Role>().Where(r => r.RoleId == key).FirstOrDefault();
        }

        public List<Role> GetRoles()
        {
            return context.Set<Role>().ToList();
        }



        public void UpdateRole(Role role)
        {
            context.Entry(role).State = EntityState.Modified;
        }
    }
}
