using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/[controller]")]
public class BookingsController : BaseApi
{
    private readonly IBaseServices<Booking> _bookingServices;
    public BookingsController(IMapper mapper, IBaseServices<Booking> bookingServices) : base(mapper)
    {
        _bookingServices = bookingServices;
    }

    #region Queries
    #endregion

    #region Commands
    #endregion
}
