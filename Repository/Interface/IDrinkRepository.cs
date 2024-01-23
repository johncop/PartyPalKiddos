using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IDrinkRepository
    {
        void addDrink(Drink d);
        void removeDrink(Drink d);
        void UpdateDrink(Drink d);
        List<Drink> GetAllDrinks();
        Drink GetDrinkById(int id);
        List<Drink> GetDrinkByName(string DrinkName);
    }
}
