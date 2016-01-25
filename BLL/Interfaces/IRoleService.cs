using Entity;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        void AddRole(Role role);
        void DeleteRole(Role role);
        void UpdateRole(Role role);
        List<Role> GetAllRoles();
        Role GetRoleById(int key);
    }
}
