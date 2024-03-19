using BusinessObject.Models;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ITimeSlotRepository
    {
        void AddTimeSlot(TimeSlot timeSlot);
        void RemoveTimeSlot(TimeSlot timeSlot);
        void UpdateTimeSlot(TimeSlot timeSlot);
        List<TimeSlot> GetAllTimeSlots();
        TimeSlot GetTimeSlotById(int id);
    }
}
