﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class addHostFoodDetail
    {
        [Key]
        public int? HostId { get; set; }
        public int? FoodId { get; set; }
    }
}
