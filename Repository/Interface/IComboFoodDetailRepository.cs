using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IComboFoodDetailRepository
    {
        void addComboFoodDetail(ComboFoodDetail comboFoodDetail);
        void removeComboFoodDetail(ComboFoodDetail comboFoodDetail);
        void UpdateComboFoodDetail(ComboFoodDetail comboFoodDetail);
        ComboFoodDetail GetComboFoodDetailByComboId(int comboId);
        List<ComboFoodDetail> GetAllComboFoodDetail();
    }
}
