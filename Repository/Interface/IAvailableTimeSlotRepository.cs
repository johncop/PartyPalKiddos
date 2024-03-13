using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IAvailableTimeSlotRepository
    {
        void AddAvailableTimeSlot(AvailableTimeSlot timeSlot);
        void RemoveAvailableTimeSlot(AvailableTimeSlot timeSlot);
        void UpdateAvailableTimeSlot(AvailableTimeSlot timeSlot);
        List<AvailableTimeSlot> GetAllAvailableTimeSlots();
        AvailableTimeSlot GetAvailableTimeSlotById(int id);
    }
}
