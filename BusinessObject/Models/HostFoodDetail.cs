using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class HostFoodDetail
    {
        public HostFoodDetail(int? hostId, int? foodId)
        {
            HostId = hostId;
            FoodId = foodId;
        }

        public int? HostId { get; set; }
        public int? FoodId { get; set; }

        public virtual Food? Food { get; set; }
        public virtual Host? Host { get; set; }
    }
}
