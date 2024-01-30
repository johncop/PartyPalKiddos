using BusinessObject.Models;
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
        public void addDrink(Drink d)
        {
            throw new NotImplementedException();
        }

        public List<Drink> GetAllDrinks()
        {
            throw new NotImplementedException();
        }

        public Drink GetDrinkById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Drink> GetDrinkByName(string DrinkName)
        {
            throw new NotImplementedException();
        }

        public void removeDrink(Drink d)
        {
            throw new NotImplementedException();
        }

        public void UpdateDrink(Drink d)
        {
            throw new NotImplementedException();
        }
    }
}
