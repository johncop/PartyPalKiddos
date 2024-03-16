using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public partial class HostFoodDetail
    {
        public HostFoodDetail()
        {

        }
        public HostFoodDetail(int? hostId, int? foodId)
        {
            HostId = hostId;
            FoodId = foodId;
        }
        [Key]
        public int? HostId { get; set; }
        public int? FoodId { get; set; }

        public virtual Food? Food { get; set; }
        public virtual Host? Host { get; set; }
    }
}
