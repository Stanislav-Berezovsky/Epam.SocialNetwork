using BLL.Interfaces;
using DAL.Interfaces;
using Entity;
using System.Collections.Generic;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }
        public void AddRole(Role role)
        {
            roleRepository.AddRole(role);
            uow.Commit();
        }

        public void DeleteRole(Role role)
        {
            roleRepository.DeleteRole(role);
            uow.Commit();
        }

        public List<Role> GetAllRoles()
        {
            return roleRepository.GetRoles();
        }

        public void UpdateRole(Role role)
        {
            roleRepository.UpdateRole(role);
        }

        public Role GetRoleById(int key)
        {
            return roleRepository.GetRoleById(key);
        }
    }
}
