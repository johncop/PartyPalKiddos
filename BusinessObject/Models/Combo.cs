using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Combo
    {
        public Combo() { }
        public Combo(string? comboName, decimal? comboPrice, int? hostId, string? imgUrl, int? status)
        {
            ComboName = comboName;
            ComboPrice = comboPrice;
            HostId = hostId;
            ImgUrl = imgUrl;
            Status = status;
        }

        public Combo(int id, string? comboName, decimal? comboPrice, int? hostId, string? imgUrl, int? status)
        {
            Id = id;
            ComboName = comboName;
            ComboPrice = comboPrice;
            HostId = hostId;
            ImgUrl = imgUrl;
            Status = status;
        }

        public int Id { get; set; }
        public string? ComboName { get; set; }
        public decimal? ComboPrice { get; set; }
        public int? HostId { get; set; }
        public string? ImgUrl { get; set; }
        public int? Status { get; set; }

        public virtual Host? Host { get; set; }
    }
}
