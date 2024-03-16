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
        public HostComboDetail(int? hostId, int? comboId)
        {
            HostId = hostId;
            ComboId = comboId;
        }
        [Key]
        public int? HostId { get; set; }
        public int? ComboId { get; set; }

        public virtual Combo? Combo { get; set; }
        public virtual Host? Host { get; set; }
    }
}
