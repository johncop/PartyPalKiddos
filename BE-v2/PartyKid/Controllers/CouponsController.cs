using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/[controller]")]
public class CouponsController : BaseApi
{
    private readonly IBaseServices<Coupon> _couponServices;
    public CouponsController(IBaseServices<Coupon> couponServices, IMapper mapper) : base(mapper)
    {
        _couponServices = couponServices;
    }

    #region Queries

    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        return Success<IList<CouponResponseDTO>>(data: await _couponServices.GetAllAsync<CouponResponseDTO>(filter: x => !x.IsDeleted));
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> GetById([FromRoute(Name = "Id")] int id)
    {
        CouponResponseDTO coupon = _mapper.Map<CouponResponseDTO>(await _couponServices.Find(filter: x => x.Id == id));
        return Success<CouponResponseDTO>(data: coupon);
    }
    #endregion

    #region Commands
    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] AddCouponBindingModel request)
    {
        Coupon coupon = _mapper.Map<Coupon>(request);
        string result = await _couponServices.Create(coupon);
        return Success(message: result);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateCouponBindingModel request)
    {
        Coupon coupon = await _couponServices.Find(filter: x => x.Id == id);
        if (coupon is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        coupon = _mapper.Map(request, coupon);
        CouponResponseDTO result = _mapper.Map<CouponResponseDTO>(await _couponServices.Update(coupon));
        return Success<CouponResponseDTO>(data: result);

    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        Coupon coupon = await _couponServices.Find(filter: x => x.Id == id);
        if (coupon is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        return Success(message: await _couponServices.Delete(coupon));
    }
    #endregion
}
