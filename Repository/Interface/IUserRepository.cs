using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        void addUser(User d);
        void removeUser(User d);
        void UpdateUser(User d);
        List<User> GetAllUsers();
        User GetUserById(int id);
    }
}
