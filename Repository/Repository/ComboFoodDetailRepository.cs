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
    public class ComboFoodDetailRepository : IComboFoodDetailRepository
    {
        public void addComboFoodDetail(ComboFoodDetail comboFoodDetail) => ComboFoodDetailDAO.SaveComboFoodDetail(comboFoodDetail);

        public List<ComboFoodDetail> GetAllComboFoodDetail() => ComboFoodDetailDAO.GetComboFoodDetails();

        public ComboFoodDetail GetComboFoodDetailByComboId(int comboId) => ComboFoodDetailDAO.findComboFoodDetailByComboId(comboId);

        public void removeComboFoodDetail(ComboFoodDetail comboFoodDetail) => ComboFoodDetailDAO.DeleteComboFoodDetail(comboFoodDetail);

        public void UpdateComboFoodDetail(ComboFoodDetail comboFoodDetail) => ComboFoodDetailDAO.UpdateComboFoodDetail(comboFoodDetail);
    }
}
