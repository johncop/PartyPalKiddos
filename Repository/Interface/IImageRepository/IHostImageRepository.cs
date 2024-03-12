using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Image
{
    public interface IHostImageRepository
    {
        void addHostImage(HostImage li);
        void removeHostImage(HostImage li);
        void UpdateHostImage(HostImage li);
        List<HostImage> GetAllHostImages();
        HostImage GetHostImageById(int id);
    }
}
