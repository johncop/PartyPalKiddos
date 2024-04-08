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
    public BookingsController(IMapper mapper, IBaseServices<Booking> bookingServices, IUserServices userServices) : base(mapper)
    {
        _bookingServices = bookingServices;
        _userSerivces = userServices;
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

        var booking = await _bookingServices.GetAllAsync<BookingResponseDTO>(filter: x => x.UserId == currUser.Id,
                                                                        includeEntities: x => x.BookingDetails);
        return Success<IList<BookingResponseDTO>>(data: booking);
    }

    [Authorize]
    [HttpGet]
    [Route("Id")]
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

        BookingResponseDTO booking = await _bookingServices.Query(filter: x => x.Id == bookingId && x.UserId == currUser.Id, includeEntities: x => x.BookingDetails)
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
        if (request.Combos is not null && request.Combos.Count > 0)
        {
            booking.BookingDetails = new List<BookingDetail>();
            foreach (var combo in request.Combos)
            {
                booking.BookingDetails.Add(new BookingDetail()
                {
                    BookingId = booking.Id,
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
                    BookingId = booking.Id,
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

        return Success(message: await _bookingServices.Create(booking));
    }
    #endregion
}
