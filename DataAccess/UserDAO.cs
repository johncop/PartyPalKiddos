using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {
        public static List<User> GetUsers()
        {
            var listUser = new List<User>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listUser = context.Users
                .Select(user => new User
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Password = user.Password,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role,
                    Status = user.Status,
                }).ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listUser;
        }
        public static User findUserById(int id)
        {
            User p = new User();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.Users
                .Select(user => new User
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Password = user.Password,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role,
                    Status = user.Status,
                }).SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }
        public static void SaveUser(User user)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteUser(User user)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.Users.SingleOrDefault(x => x.Id == user.Id);
                    context.Users.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdateUser(User user)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<User>(user).State =
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
