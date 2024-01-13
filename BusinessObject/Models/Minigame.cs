using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Minigame
    {
        public Minigame()
        {
            CouponBanks = new HashSet<CouponBank>();
        }

        public int Id { get; set; }
        public string GameName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<CouponBank> CouponBanks { get; set; }
    }
}
