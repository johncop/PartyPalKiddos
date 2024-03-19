using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IDistrictRepository
    {
        void addDistrict(District d);
        void removeDistrict(District d);
        void UpdateDistrict(District d);
        List<District> GetAllDistricts();
        District GetDistrictById(int id);
        List<District> GetDistrictByName(string DistrictName);
    }
}
