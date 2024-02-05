using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Image
{
    public interface IFoodImageRepository
    {
        void addFoodImage(FoodImage fi);
        void removeFoodImage(FoodImage fi);
        void UpdateFoodImage(FoodImage fi);
        List<FoodImage> GetAllFoodImages();
        FoodImage GetFoodImageById(int id);
    }
}
