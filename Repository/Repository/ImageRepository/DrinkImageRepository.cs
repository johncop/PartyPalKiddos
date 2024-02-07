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
    public class DrinkImageRepository : IDrinkImageRepository
    {
        public void addDrinkImage(DrinkImage di) => DrinkImageDAO.SaveDrinkImage(di);

        public List<DrinkImage> GetAllDrinkImages() => DrinkImageDAO.GetDrinkImages();

        public DrinkImage GetDrinkImageById(int id) => DrinkImageDAO.findDrinkImageById(id);

        public void removeDrinkImage(DrinkImage di) => DrinkImageDAO.DeleteDrinkImage(di);

        public void UpdateDrinkImage(DrinkImage di) => DrinkImageDAO.UpdateDrinkImage(di);
    }
}
