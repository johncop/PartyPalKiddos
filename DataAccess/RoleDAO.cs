using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleDAO
    {
        public static List<Role> GetRoles()
        {
            var listRole = new List<Role>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listRole = context.Roles
                .Select(role => new Role
                {
                    Id = role.Id,
                    RoleName = role.RoleName,
                    Status = role.Status,
                }).ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listRole;
        }
        public static Role findRoleById(int id)
        {
            Role p = new Role();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.Roles
                .Select(role => new Role
                {
                    Id = role.Id,
                    RoleName = role.RoleName,
                    Status = role.Status,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }
        public static void SaveRole(Role role)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteRole(Role role)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.Roles.SingleOrDefault(x => x.Id == role.Id);
                    context.Roles.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateRole(Role role)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<Role>(role).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
