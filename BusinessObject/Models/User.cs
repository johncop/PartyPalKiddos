using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class User
    {

        public User()
        {
            Orders = new HashSet<Order>();
            Packages = new HashSet<Package>();
        }

        public User(int id, string firstName, string lastName, string email, string password, string address, string phoneNumber, int? roleId, int? status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Address = address;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
            Status = status;
        }
        public User(string firstName, string lastName, string email, string password, string address, string phoneNumber, int? roleId, int? status)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Address = address;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
            Status = status;
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? RoleId { get; set; }
        public int? Status { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
