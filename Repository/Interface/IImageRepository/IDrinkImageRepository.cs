using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Image
{
    public interface IDrinkImageRepository
    {
        void addDrinkImage(DrinkImage di);
        void removeDrinkImage(DrinkImage di);
        void UpdateDrinkImage(DrinkImage di);
        List<DrinkImage> GetAllDrinkImages();
        DrinkImage GetDrinkImageById(int id);
    }
}
