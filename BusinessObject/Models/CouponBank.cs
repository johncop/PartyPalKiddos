using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class CouponBank
    {
        public int Id { get; set; }
        public int? MinigameId { get; set; }
        public int? CouponId { get; set; }

        public virtual Coupon? Coupon { get; set; }
        public virtual Minigame? Minigame { get; set; }
    }
}
