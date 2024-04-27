using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

[Route("api/[controller]")]
public class BookingsController : BaseApi
{
    private readonly IBaseServices<Booking> _bookingServices;
    private readonly IUserServices _userSerivces;
    private readonly IEmailServices _emailServices;
    private readonly DbContext _dbContext;
    public BookingsController(IMapper mapper,
                              IBaseServices<Booking> bookingServices,
                              IUserServices userServices,
                              IEmailServices emailServices, DbContext dbContext) : base(mapper)
    {
        _bookingServices = bookingServices;
        _userSerivces = userServices;
        _emailServices = emailServices;
        _dbContext = dbContext;
    }

    #region Queries

    [Authorize]
    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        ApplicationUser currUser = await _userSerivces.GetCurrentUser();
        if (currUser is null)
        {
            throw new DomainException(Constants.AuthHandling.Messages.NotFoundUser);
        }

        await _emailServices.Send(currUser.Email, "Test", "Test content");

        var booking = await _bookingServices.Query(filter: x => x.UserId == currUser.Id)
                                            .Include(x => x.BookingDetails)
                                            .ProjectTo<BookingResponseDTO>(_mapper.ConfigurationProvider)
                                            .ToListAsync();
        return Success<IList<BookingResponseDTO>>(data: booking);
    }

    [Authorize]
    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int bookingId)
    {
        if (bookingId == 0)
        {
            throw new DomainException(Constants.BookingHandling.Messages.IdEmpty);
        }

        ApplicationUser currUser = await _userSerivces.GetCurrentUser();
        if (currUser is null)
        {
            throw new DomainException(Constants.AuthHandling.Messages.NotFoundUser);
        }

        BookingResponseDTO booking = await _bookingServices.Query(filter: x => x.Id == bookingId && x.UserId == currUser.Id)
                                                            .Include(x => x.BookingDetails)
                                                            .Include(x => x.BookingTimeSlots)
                                                            .ProjectTo<BookingResponseDTO>(_mapper.ConfigurationProvider)
                                                            .FirstOrDefaultAsync();
        return Success<BookingResponseDTO>(data: booking);
    }

    #endregion

    #region Commands
    [HttpPost]
    [Authorize]
    public async Task<IResponse> Create([FromBody] CreateBookingBindingModel request)
    {
        ApplicationUser currUser = await _userSerivces.GetCurrentUser();
        if (currUser is null)
        {
            throw new DomainException(Constants.AuthHandling.Messages.NotFoundUser);
        }

        Booking booking = _mapper.Map<Booking>(request);
        booking.UserId = currUser.Id;

        if (request.BookingTimeSlots is not null && request.BookingTimeSlots.Count > 0)
        {
            booking.BookingTimeSlots = new List<BookingTimeSlot>();
            foreach (int timeSlotId in request.BookingTimeSlots)
            {
                booking.BookingTimeSlots.Add(new BookingTimeSlot()
                {
                    TimeSlotId = timeSlotId
                });
            }
        }

        booking.BookingDetails = new List<BookingDetail>();
        if (request.Combos is not null && request.Combos.Count > 0)
        {
            foreach (var combo in request.Combos)
            {
                booking.BookingDetails.Add(new BookingDetail()
                {
                    ComboId = combo.Id,
                    ComboQuantity = combo.Quantity
                });
            }
        }

        if (request.Foods is not null && request.Foods.Count > 0)
        {
            foreach (var food in request.Foods)
            {
                booking.BookingDetails.Add(new BookingDetail()
                {
                    FoodId = food.Id,
                    FoodQuantity = food.Quantity
                });
            }
        }

        if (request.Services is not null && request.Services.Count > 0)
        {
            foreach (var service in request.Services)
            {
                booking.BookingDetails.Add(new BookingDetail()
                {
                    ServiceId = service.Id,
                    ServiceQuantity = service.Quantity
                });
            }
        }

        if (request.ServicePackages is not null && request.ServicePackages.Count > 0)
        {
            foreach (var servicePackage in request.ServicePackages)
            {
                booking.BookingDetails.Add(new BookingDetail()
                {
                    ServicePackageId = servicePackage.Id,
                    ServicePackageQuantity = servicePackage.Quantity
                });
            }
        }

        return Success(message: await _bookingServices.Create(booking));
    }

    [Authorize]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int bookingId, [FromBody] UpdateBookingBindingModel request)
    {
        ApplicationUser currUser = await _userSerivces.GetCurrentUser();
        if (currUser is null)
        {
            throw new DomainException(Constants.AuthHandling.Messages.NotFoundUser);
        }

        var booking = await _bookingServices.Query(filter: x => x.Id == bookingId &&
                                                                    !x.IsDeleted && x.UserId == currUser.Id,
                                                                    includeEntities: x => x.BookingDetails)
                                                     .FirstOrDefaultAsync();
        if (booking is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        request.Id = booking.Id;

        if (request.BookingTimeSlots is not null && request.BookingTimeSlots.Count > 0)
        {
            await _dbContext.Entry(booking).Collection(x => x.BookingTimeSlots).Query().ExecuteDeleteAsync();
            booking.BookingTimeSlots = new List<BookingTimeSlot>();
            foreach (int timeSlotId in request.BookingTimeSlots)
            {
                booking.BookingTimeSlots.Add(new BookingTimeSlot()
                {
                    TimeSlotId = timeSlotId
                });
            }
        }

        await _dbContext.Entry(booking).Collection(x => x.BookingDetails).Query().ExecuteDeleteAsync();
        if (request.Combos is not null && request.Combos.Count > 0)
        {
            booking.BookingDetails = new List<BookingDetail>();
            foreach (var combo in request.Combos)
            {
                booking.BookingDetails.Add(new BookingDetail()
                {
                    ComboId = combo.Id,
                    ComboQuantity = combo.Quantity
                });
            }
        }

        if (request.Foods is not null && request.Foods.Count > 0)
        {
            booking.BookingDetails = new List<BookingDetail>();
            foreach (var food in request.Foods)
            {
                booking.BookingDetails.Add(new BookingDetail()
                {
                    FoodId = food.Id,
                    FoodQuantity = food.Quantity
                });
            }
        }

        if (request.Services is not null && request.Services.Count > 0)
        {
            booking.BookingDetails = new List<BookingDetail>();
            foreach (var service in request.Services)
            {
                booking.BookingDetails.Add(new BookingDetail()
                {
                    ServiceId = service.Id,
                    ServiceQuantity = service.Quantity
                });
            }
        }

        if (request.ServicePackages is not null && request.ServicePackages.Count > 0)
        {
            booking.BookingDetails = new List<BookingDetail>();
            foreach (var servicePackage in request.ServicePackages)
            {
                booking.BookingDetails.Add(new BookingDetail()
                {
                    ServicePackageId = servicePackage.Id,
                    ServicePackageQuantity = servicePackage.Quantity
                });
            }
        }

        booking = _mapper.Map(request, booking);
        return Success<BookingResponseDTO>(data: _mapper.Map<BookingResponseDTO>(await _bookingServices.Update(booking)));
    }
    #endregion
}
