using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class BookingFoodDetail
    {
        public int? BookingId { get; set; }
        public int? FoodId { get; set; }
        public int? ComboId { get; set; }
        public int? FoodQuantity { get; set; }
        public int? ComboQuantity { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Combo? Combo { get; set; }
        public virtual Food? Food { get; set; }
    }
}
