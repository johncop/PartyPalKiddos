using BusinessObject.Models;
using DataAccess.ImageDAO;
using Repository.Interface.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.ImageRepository
{
    public class LocationImageRepository : ILocationImageRepository
    {
        public void addLocationImage(LocationImage li) => LocationImageDAO.SaveLocationImage(li);

        public List<LocationImage> GetAllLocationImages() => LocationImageDAO.GetLocationImages();

        public LocationImage GetLocationImageById(int id) => LocationImageDAO.findLocationImageById(id);

        public void removeLocationImage(LocationImage li) => LocationImageDAO.DeleteLocationImage(li);

        public void UpdateLocationImage(LocationImage li) => LocationImageDAO.UpdateLocationImage(li);
    }
}
