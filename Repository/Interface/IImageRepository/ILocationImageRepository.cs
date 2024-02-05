using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Image
{
    public interface ILocationImageRepository
    {
        void addLocationImage(LocationImage li);
        void removeLocationImage(LocationImage li);
        void UpdateLocationImage(LocationImage li);
        List<LocationImage> GetAllLocationImages();
        LocationImage GetLocationImageById(int id);
    }
}
