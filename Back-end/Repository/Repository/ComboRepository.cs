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
    public class ComboRepository : IComboRepository
    {
        public void addCombo(Combo combo) => ComboDAO.SaveCombo(combo);

        public List<Combo> GetAllCombo() => ComboDAO.GetCombos();

        public List<Combo> GetComboByHostId(int hostId) =>  ComboDAO.findComboByHostId(hostId);

        public Combo GetComboById(int id) => ComboDAO.findComboById(id);
        public List<Combo> GetComboByName(string comboName) => ComboDAO.findComboByName(comboName);

        public void removeCombo(Combo combo) => ComboDAO.DeleteCombo(combo);

        public void UpdateCombo(Combo combo) => ComboDAO.UpdateCombo(combo);
    }
}
