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
    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        return Success<IList<FoodResponseDTO>>(data: await _foodServices.GetAllAsync<FoodResponseDTO>(filter: x => !x.IsDeleted, includeEntities: x => x.FoodCategory));
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        Food food = await _foodServices.Find(id);
        if (food is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        return Success<FoodResponseDTO>(data: _mapper.Map<FoodResponseDTO>(food));
    }

    #endregion

    #region Commands

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] CreateFoodBindingModel request)
    {
        Food food = _mapper.Map<Food>(request);
        return Success(message: await _foodServices.Create(food));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateFoodBindingModel request)
    {
        Food food = await _foodServices.Find(id);
        if (food is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        food = _mapper.Map<Food>(request);
        return Success<FoodResponseDTO>(data: _mapper.Map<FoodResponseDTO>(await _foodServices.Update(food)));
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        Food food = await _foodServices.Find(id);
        if (food is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        return Success(message: await _foodServices.Delete(id));
    }
    #endregion
}
