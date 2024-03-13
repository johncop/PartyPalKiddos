using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System.Collections.Generic;

namespace Repository.Repository
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        public void AddTimeSlot(TimeSlot timeSlot) => TimeSlotDAO.SaveTimeSlot(timeSlot);

        public List<TimeSlot> GetAllTimeSlots() => TimeSlotDAO.GetTimeSlots();

        public TimeSlot GetTimeSlotById(int id) => TimeSlotDAO.FindTimeSlotById(id);

        public void RemoveTimeSlot(TimeSlot timeSlot) => TimeSlotDAO.DeleteTimeSlot(timeSlot);

        public void UpdateTimeSlot(TimeSlot timeSlot) => TimeSlotDAO.UpdateTimeSlot(timeSlot);
    }
}
