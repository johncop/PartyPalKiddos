using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public partial class HostComboDetail
    {
        public HostComboDetail()
        {

        }
        public HostComboDetail(int? hostId, int? comboId, int? foodId)
        {
            HostId = hostId;
            ComboId = comboId;
            FoodId = foodId;
        }
        [Key]
        public int? HostId { get; set; }
        public int? ComboId { get; set; }
        public int? FoodId { get; set; }

        public virtual Combo? Combo { get; set; }
        public virtual Food? Food { get; set; }
        public virtual Host? Host { get; set; }
    }
}
