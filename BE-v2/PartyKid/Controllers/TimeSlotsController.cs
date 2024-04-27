using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

[Route("api/time-slots")]
public class TimeSlotsController : BaseApi
{
    private readonly IBaseServices<TimeSlot> _timeSlotServices;
    private readonly IBaseServices<Booking> _bookingServices;
    public TimeSlotsController(IMapper mapper, IBaseServices<TimeSlot> timeSlotServices, IBaseServices<Booking> bookingServices) : base(mapper)
    {
        _timeSlotServices = timeSlotServices;
        _bookingServices = bookingServices;
    }

    #region Queries

    [HttpGet]
    [Route("{VenueId}/{BookingDate:datetime}")]
    public async Task<IResponse> GetAll([FromRoute(Name = "VenueId")] int venueId, [FromRoute(Name = "BookingDate")] DateTime bookingDate)
    {
        IList<TimeSlotsResponseDTO> timeslots = await _timeSlotServices.Query(x => x.VenueId == venueId)
                                                                .Include(x => x.BookingTimeSlots)
                                                                .Where(x => !x.BookingTimeSlots.Any(x => x.Booking.BookingDate.Date.Equals(bookingDate.Date)))
                                                                .ProjectTo<TimeSlotsResponseDTO>(_mapper.ConfigurationProvider)
                                                                .ToListAsync();
        return Success<IList<TimeSlotsResponseDTO>>(data: timeslots);
    }

    #endregion

    #region Commands

    [HttpPost]
    public async Task<IResponse> Create([FromBody] AddTimeSlotBindingModel request)
    {
        TimeSlot timeSlot = _mapper.Map<TimeSlot>(request);
        return Success(message: await _timeSlotServices.Create(timeSlot));
    }
    #endregion
}
