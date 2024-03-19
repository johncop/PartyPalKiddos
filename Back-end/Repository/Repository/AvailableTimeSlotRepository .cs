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
    public class AvailableTimeSlotRepository : IAvailableTimeSlotRepository
    {
        public void AddAvailableTimeSlot(AvailableTimeSlot timeSlot) => AvailableTimeSlotDAO.SaveAvailableTimeSlot(timeSlot);

        public List<AvailableTimeSlot> GetAllAvailableTimeSlots() => AvailableTimeSlotDAO.GetAvailableTimeSlots();

        public AvailableTimeSlot GetAvailableTimeSlotById(int id) => AvailableTimeSlotDAO.FindAvailableTimeSlotById(id);

        public void RemoveAvailableTimeSlot(AvailableTimeSlot timeSlot) => AvailableTimeSlotDAO.DeleteAvailableTimeSlot(timeSlot);

        public void UpdateAvailableTimeSlot(AvailableTimeSlot timeSlot) => AvailableTimeSlotDAO.UpdateAvailableTimeSlot(timeSlot);
    }
}
