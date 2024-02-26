using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PackageDetailDAO
    {
        #region query
        public static List<PackageDetail> GetPackageDetails()
        {
            var listOrder = new List<PackageDetail>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    listOrder = context.PackageDetails
                .Select(pd => new PackageDetail
                {
                    PackageId = pd.PackageId,
                    ServiceId = pd.ServiceId,
                    Quantity = pd.Quantity,
                }).ToList();
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrder;
        }

        public static PackageDetail findPackageDetailByPackageId(int id)
        {
            PackageDetail p = new PackageDetail();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    p = context.PackageDetails
                .Select(pd => new PackageDetail
                {
                    PackageId = pd.PackageId,
                    ServiceId = pd.ServiceId,
                    Quantity = pd.Quantity,
                }).SingleOrDefault(x => x.PackageId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static List<PackageDetail> findServiceByPackageId(int packageId)
        {
            List<PackageDetail> pt = new List<PackageDetail>();
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    pt = context.PackageDetails
                .Where(PackageDetail => PackageDetail.PackageId == packageId)
                .Select(pd => new PackageDetail
                {
                    PackageId = pd.PackageId,
                    ServiceId = pd.ServiceId,
                    Quantity = pd.Quantity,
                }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return pt;
        }
        #endregion

        #region command
        public static void SavePackageDetail(PackageDetail pd)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.PackageDetails.Add(pd);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeletePackageDetail(PackageDetail pd)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    var p1 = context.PackageDetails.SingleOrDefault(x => x.PackageId == pd.PackageId);
                    context.PackageDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public static void UpdatePackageDetail(PackageDetail pd)
        {
            try
            {
                using (var context = new PartyPalKiddosContext())
                {
                    context.Entry<PackageDetail>(pd).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
