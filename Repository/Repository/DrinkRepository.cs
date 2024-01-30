using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class DrinkRepository : IDrinkRepository
    {
        public void addDrink(Drink d) => DrinkDAO.SaveDrink(d);

        public List<Drink> GetAllDrinks() => DrinkDAO.GetDrinks();

        public Drink GetDrinkById(int id) => DrinkDAO.findDrinkById(id);

        public List<Drink> GetDrinkByName(string DrinkName) => DrinkDAO.findDrinkByName(DrinkName);

        public void removeDrink(Drink d) => DrinkDAO.DeleteDrink(d);

        public void UpdateDrink(Drink d) => DrinkDAO.UpdateDrink(d);
    }
}
