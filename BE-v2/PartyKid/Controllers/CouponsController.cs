using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/[controller]")]
public class CouponsController : BaseApi
{
    private readonly IBaseServices<Coupon> _couponServices;

    public CouponsController(IBaseServices<Coupon> couponService, IMapper mapper) : base(mapper)
    {
        _couponServices = couponService;
    }

    #region Queries

    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        return Success<IList<CouponResponseDTO>>(data: await _couponServices.GetAllAsync<CouponResponseDTO>());
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> GetById([FromRoute(Name = "Id")] int id)
    {
        CouponResponseDTO coupon = _mapper.Map<CouponResponseDTO>(await _couponServices.Find(id));
        return Success<CouponResponseDTO>(data: coupon);
    }
    #endregion

    #region Commands
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] AddCouponBindingModel request)
    {
        Coupon coupon = _mapper.Map<Coupon>(request);
        var result = await _couponServices.Create(coupon);
        return Success(message: result);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateCouponBindingModel request)
    {
        request.Id = id;
        CouponResponseDTO result = _mapper.Map<CouponResponseDTO>(await _couponServices.Update(_mapper.Map<Coupon>(request)));
        return Success<CouponResponseDTO>(data: result);

    }
    #endregion
}
