using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRoleRepository
    {
        void addRole(Role d);
        void removeRole(Role d);
        void UpdateRole(Role d);
        List<Role> GetAllRoles();
        Role GetRoleById(int id);
    }
}
