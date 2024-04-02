using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/[controller]")]
public class FoodsController : BaseApi
{
    private readonly IBaseServices<Food> _foodServices;
    public FoodsController(IMapper mapper, IBaseServices<Food> foodServices) : base(mapper)
    {
        _foodServices = foodServices;
    }

    #region Queries

    #endregion

    #region Commands
    #endregion
}
