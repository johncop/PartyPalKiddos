using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TimeSlotDAO
    {
        public static List<TimeSlot> GetTimeSlots()
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var listTimeSlots = context.TimeSlots
                        .Select(timeSlot => new TimeSlot
                        {
                            Id = timeSlot.Id,
                            Hours = timeSlot.Hours,
                            Weekday = timeSlot.Weekday,
                            Status = timeSlot.Status
                        }).ToList();
                    return listTimeSlots;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static TimeSlot FindTimeSlotById(int id)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var timeSlot = context.TimeSlots
                        .Select(timeSlot => new TimeSlot
                        {
                            Id = timeSlot.Id,
                            Hours = timeSlot.Hours,
                            Weekday = timeSlot.Weekday,
                            Status = timeSlot.Status
                        }).SingleOrDefault(x => x.Id == id);
                    return timeSlot;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static void SaveTimeSlot(TimeSlot timeSlot)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.TimeSlots.Add(timeSlot);
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static void DeleteTimeSlot(TimeSlot timeSlot)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var ts = context.TimeSlots.SingleOrDefault(x => x.Id == timeSlot.Id);
                    context.TimeSlots.Remove(ts);
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static void UpdateTimeSlot(TimeSlot timeSlot)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<TimeSlot>(timeSlot).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
