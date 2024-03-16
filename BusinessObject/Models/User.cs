using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RoleId { get; set; }
        public int? Status { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
