using BusinessObject.Models;
using DataAccess.ImageDAO;
using Repository.Interface.IImageRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.ImageRepository
{
    public class PackageImageRepository : IPackageImageRepository
    {
        public void addPackageImage(PackageImage pi) => PackageImageDAO.SavePackageImage(pi);

        public List<PackageImage> GetAllPackageImages() => PackageImageDAO.GetPackageImages();

        public PackageImage GetPackageImageById(int id) => PackageImageDAO.findPackageImageById(id);

        public void removePackageImage(PackageImage pi) => PackageImageDAO.DeletePackageImage(pi);

        public void UpdatePackageImage(PackageImage pi) => PackageImageDAO.UpdatePackageImage(pi);
    }
}
