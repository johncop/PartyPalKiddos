using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.IImageRepository
{
    public interface IPackageImageRepository
    {
        void addPackageImage(PackageImage si);
        void removePackageImage(PackageImage si);
        void UpdatePackageImage(PackageImage si);
        List<PackageImage> GetAllPackageImages();
        PackageImage GetPackageImageById(int id);
    }
}
