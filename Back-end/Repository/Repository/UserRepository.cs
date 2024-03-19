using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        public void addUser(User user) => UserDAO.SaveUser(user);

        public List<User> GetAllUsers() => UserDAO.GetUsers();

        public User GetUserById(int id) => UserDAO.findUserById(id);

        public void removeUser(User user) => UserDAO.DeleteUser(user);

        public void UpdateUser(User user) => UserDAO.UpdateUser(user);
    }
}
