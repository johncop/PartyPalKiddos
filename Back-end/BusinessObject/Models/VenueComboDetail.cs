﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class VenueComboDetail
    {
        public VenueComboDetail()
        {

        }
        public VenueComboDetail(int? venueId, int? comboId)
        {
            VenueId = venueId;
            ComboId = comboId;
        }

        public int? VenueId { get; set; }
        public int? ComboId { get; set; }

        public virtual Combo? Combo { get; set; }
        public virtual Venue? Venue { get; set; }
    }
}
