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
    public class FoodImageRepository : IFoodImageRepository
    {
        public void addFoodImage(FoodImage fi) => FoodImageDAO.SaveFoodImage(fi);

        public List<FoodImage> GetAllFoodImages() => FoodImageDAO.GetFoodImages();

        public FoodImage GetFoodImageById(int id) => FoodImageDAO.findFoodImageById(id);

        public void removeFoodImage(FoodImage fi) => FoodImageDAO.DeleteFoodImage(fi);

        public void UpdateFoodImage(FoodImage fi) => FoodImageDAO.UpdateFoodImage(fi);
    }
}
