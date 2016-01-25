using Entity;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRoleRepository
    {
        void AddRole(Role role);
        void DeleteRole(Role role);
        void UpdateRole(Role role);
        List<Role> GetRoles();
        Role GetRoleById(int key);

    }
}
