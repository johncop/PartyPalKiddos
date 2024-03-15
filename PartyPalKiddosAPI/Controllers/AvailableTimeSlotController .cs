using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;

namespace PartyPalKiddosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableTimeSlotController : ControllerBase
    {
        private IAvailableTimeSlotRepository repository = new AvailableTimeSlotRepository();

        [HttpPost("AvailableTimeSlots")]
        public IActionResult PostAvailableTimeSlot(int? timeslotId, int? hostId, string? status)
        {
            AvailableTimeSlot timeSlot = new AvailableTimeSlot
            {
                TimeslotId = timeslotId,
                HostId = hostId,
                Status = status
            };
            repository.AddAvailableTimeSlot(timeSlot);
            return Ok(new { success = true, message = "Time Slot Added successfully." });
        }

        [HttpPut("AvailableTimeSlots")]
        public IActionResult UpdateAvailableTimeSlot(int id, int? timeslotId, int? hostId, string? status)
        {
            var checkTimeSlot = repository.GetAvailableTimeSlotById(id);
            if (checkTimeSlot == null)
            {
                return NotFound();
            }

            AvailableTimeSlot timeSlot = new AvailableTimeSlot
            {
                Id = id,
                TimeslotId = timeslotId,
                HostId = hostId,
                Status = status
            };
            repository.UpdateAvailableTimeSlot(timeSlot);
            return Ok(new { success = true, message = "Time Slot updated successfully." });
        }

        [HttpDelete("AvailableTimeSlots")]
        public IActionResult DeleteAvailableTimeSlot(int id)
        {
            var timeSlot = repository.GetAvailableTimeSlotById(id);
            if (timeSlot == null)
            {
                return NotFound();
            }
            repository.RemoveAvailableTimeSlot(timeSlot);
            return Ok(new { success = true, message = "Time Slot deleted successfully." });
        }

        [HttpGet("AvailableTimeSlots")]
        public ActionResult<IEnumerable<AvailableTimeSlot>> GetAllAvailableTimeSlots() => repository.GetAllAvailableTimeSlots();

        [HttpGet("AvailableTimeSlots/{id}")]
        public ActionResult<AvailableTimeSlot> GetAvailableTimeSlotById(int id) => repository.GetAvailableTimeSlotById(id);
    }
}
