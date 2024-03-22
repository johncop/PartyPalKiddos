﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/coupon-types")]
public class CouponTypesController : BaseApi
{
    protected readonly IBaseServices<CouponType> _couponTypeServices;
    private readonly IMapper _mapper;

    public CouponTypesController(IBaseServices<CouponType> couponTypeServices, IMapper mapper)
    {
        _couponTypeServices = couponTypeServices;
        _mapper = mapper;
    }

    #region Queries
    [HttpGet]
    [CustomAuthorize]
    public async Task<IResponse> GetAll() => Success<IList<CouponTypesResponseDTO>>(data:
                 await _couponTypeServices.GetAllAsync<CouponTypesResponseDTO>());
    #endregion

    #region Commands

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] AddCouponTypeRequest request)
    {
        await _couponTypeServices.Create(_mapper.Map<CouponType>(request));
        return Success(message: Constants.Transactions.Messages.AddComplete);
    }

    [CustomAuthorize]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromBody] UpdateCouponTypeRequest request, [FromRoute(Name = "Id")] int id)
    {
        request.Id = id;
        CouponType entity = await _couponTypeServices.Update(_mapper.Map<CouponType>(request));
        return Success<CouponTypesResponseDTO>(data: _mapper.Map<CouponTypesResponseDTO>(entity));
    }

    [CustomAuthorize]
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        return Success(message: await _couponTypeServices.Delete(id));
    }
    #endregion
}
