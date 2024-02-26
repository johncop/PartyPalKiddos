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
    public class DistrictRepository : IDistrictRepository
    {
        public void addDistrict(District d) => DistrictDAO.SaveDistrict(d);

        public List<District> GetAllDistricts() => DistrictDAO.GetDistricts();

        public District GetDistrictById(int id) => DistrictDAO.findDistrictById(id);

        public List<District> GetDistrictByName(string description) => DistrictDAO.findDistrictByName(description);

        public void removeDistrict(District d) => DistrictDAO.DeleteDistrict(d);

        public void UpdateDistrict(District d) => DistrictDAO.UpdateDistrict(d);
    }
}
