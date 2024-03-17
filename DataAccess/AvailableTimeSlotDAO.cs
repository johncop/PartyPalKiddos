using BusinessObject.Models; // Assuming AvailableTimeSlot is in the same namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AvailableTimeSlotDAO
    {
        public static List<AvailableTimeSlot> GetAvailableTimeSlots()
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var listAvailableTimeSlots = context.AvailableTimeSlots
                        .Select(timeslot => new AvailableTimeSlot
                        {
                            Id = timeslot.Id,
                            TimeslotId = timeslot.TimeslotId,
                            VenueId = timeslot.VenueId,
                            Status = timeslot.Status
                        }).ToList();
                    return listAvailableTimeSlots;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static AvailableTimeSlot FindAvailableTimeSlotById(int id)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var timeslot = context.AvailableTimeSlots
                        .Select(timeslot => new AvailableTimeSlot
                        {
                            Id = timeslot.Id,
                            TimeslotId = timeslot.TimeslotId,
                            VenueId = timeslot.VenueId,
                            Status = timeslot.Status
                        }).SingleOrDefault(x => x.Id == id);
                    return timeslot;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static void SaveAvailableTimeSlot(AvailableTimeSlot timeslot)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.AvailableTimeSlots.Add(timeslot);
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static void DeleteAvailableTimeSlot(AvailableTimeSlot timeslot)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    var t = context.AvailableTimeSlots.SingleOrDefault(x => x.Id == timeslot.Id);
                    context.AvailableTimeSlots.Remove(t);
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static void UpdateAvailableTimeSlot(AvailableTimeSlot timeslot)
        {
            try
            {
                using (var context = new PartyPalKiddosDBContext())
                {
                    context.Entry<AvailableTimeSlot>(timeslot).State =
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
