﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderFood
    {
        public int? PackageId { get; set; }
        public int? FoodId { get; set; }
        public int? Quantity { get; set; }

        public virtual Food? Food { get; set; }
        public virtual Package? Package { get; set; }
    }
}
