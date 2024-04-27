using System.Reflection.Metadata;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

[Route("api/coupon-types")]
public class CouponTypesController : BaseApi
{
    protected readonly IBaseServices<CouponType> _couponTypeServices;

    public CouponTypesController(IBaseServices<CouponType> couponTypeServices, IMapper mapper) : base(mapper)
    {
        _couponTypeServices = couponTypeServices;
    }

    #region Queries
    [HttpGet]
    public async Task<IResponse> GetAll() => Success<IList<CouponTypesResponseDTO>>(data:
                 await _couponTypeServices.GetAllAsync<CouponTypesResponseDTO>(filter: x => !x.IsDeleted));
    #endregion

    #region Commands

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] AddCouponTypeRequest request)
    {
        await _couponTypeServices.Create(_mapper.Map<CouponType>(request));
        return Success(message: Constants.Transactions.Messages.AddComplete);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromBody] UpdateCouponTypeRequest request, [FromRoute(Name = "Id")] int id)
    {
        CouponType couponType = await _couponTypeServices.Query(filter: x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
        if (couponType is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        couponType = _mapper.Map(request, couponType);
        CouponTypesResponseDTO response = _mapper.Map<CouponTypesResponseDTO>(await _couponTypeServices.Update(_mapper.Map<CouponType>(couponType)));
        return Success<CouponTypesResponseDTO>(data: response);
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        CouponType couponType = await _couponTypeServices.Find(filter: x => x.Id == id);
        if (couponType is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        return Success(message: await _couponTypeServices.Delete(couponType));
    }
    #endregion
}
