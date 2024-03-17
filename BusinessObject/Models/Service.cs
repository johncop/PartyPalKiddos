using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Service
    {
        public Service()
        {

        }

        public Service(string? serviceName, string? description, int? serviceCategoryId, string? imageUrl, byte[]? image, decimal? price)
        {
            ServiceName = serviceName;
            Description = description;
            ServiceCategoryId = serviceCategoryId;
            ImageUrl = imageUrl;
            Image = image;
            Price = price;
        }

        public Service(int id, string? serviceName, string? description, int? serviceCategoryId, string? imageUrl, byte[]? image, decimal? price)
        {
            Id = id;
            ServiceName = serviceName;
            Description = description;
            ServiceCategoryId = serviceCategoryId;
            ImageUrl = imageUrl;
            Image = image;
            Price = price;
        }

        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public int? ServiceCategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public byte[]? Image { get; set; }
        public decimal? Price { get; set; }

        public virtual ServiceCategory? ServiceCategory { get; set; }
    }
}
