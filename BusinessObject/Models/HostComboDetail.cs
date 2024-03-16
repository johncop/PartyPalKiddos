﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class HostComboDetail
    {
        public HostComboDetail(int? hostId, int? comboId)
        {
            HostId = hostId;
            ComboId = comboId;
        }

        public int? HostId { get; set; }
        public int? ComboId { get; set; }

        public virtual Combo? Combo { get; set; }
        public virtual Host? Host { get; set; }
    }
}
