using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class addVenueComboDetail
    {
        [Key]
        public int? VenueId { get; set; }
        public int? ComboId { get; set; }
    }
}
