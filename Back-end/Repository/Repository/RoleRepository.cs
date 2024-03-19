using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class RoleRepository : IRoleRepository
    {
        public void addRole(Role role) => RoleDAO.SaveRole(role);

        public List<Role> GetAllRoles() => RoleDAO.GetRoles();

        public Role GetRoleById(int id) => RoleDAO.findRoleById(id);

        public void removeRole(Role role) => RoleDAO.DeleteRole(role);

        public void UpdateRole(Role role) => RoleDAO.UpdateRole(role);
    }
}
