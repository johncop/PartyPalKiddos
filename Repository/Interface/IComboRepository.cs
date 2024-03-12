using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IComboRepository
    {
        void addCombo(Combo combo);
        void removeCombo(Combo combo);
        void UpdateCombo(Combo combo);
        Combo GetComboById(int id);
        List<Combo> GetComboByName(string comboName);
        List<Combo> GetComboByHostId(int hostId);
        List<Combo> GetAllCombo();
    }
}
