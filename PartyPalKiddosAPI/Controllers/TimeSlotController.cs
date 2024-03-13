using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;
using System.Collections.Generic;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private ITimeSlotRepository repository = new TimeSlotRepository();

        [HttpPost]
        public IActionResult PostTimeSlots(TimeSpan? Hours, string? Weekday, string? Status)
        {
            TimeSlot timeSlot = new TimeSlot
            {
                Hours = Hours,
                Weekday = Weekday,
                Status = Status
            };
            repository.AddTimeSlot(timeSlot);
            return Ok(new { success = true, message = "Time slot added successfully." });
        }

        [HttpGet]
        public ActionResult<IEnumerable<TimeSlot>> GetAllTimeSlots() => repository.GetAllTimeSlots();

        [HttpGet("{id}")]
        public ActionResult<TimeSlot> GetTimeSlotById(int id)
        {
            var timeSlot = repository.GetTimeSlotById(id);
            if (timeSlot == null)
            {
                return NotFound();
            }
            return timeSlot;
        }

        [HttpPut]
        public IActionResult UpdateTimeSlot(int Id, TimeSpan? Hours, string? Weekday, string? Status)
        {
            var checkTimeSlot = repository.GetTimeSlotById(Id);
            if (checkTimeSlot == null)
            {
                return NotFound();
            }
            TimeSlot timeSlot = new TimeSlot
            {
                Id = Id,
                Hours = Hours,
                Weekday = Weekday,
                Status = Status
            };
            repository.UpdateTimeSlot(timeSlot);
            return Ok(new { success = true, message = "Time Slot updated successfully." });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTimeSlot(int id)
        {
            var timeSlot = repository.GetTimeSlotById(id);
            if (timeSlot == null)
            {
                return NotFound();
            }
            repository.RemoveTimeSlot(timeSlot);
            return Ok(new { success = true, message = "Time Slot deleted successfully." });
        }
    }
}
