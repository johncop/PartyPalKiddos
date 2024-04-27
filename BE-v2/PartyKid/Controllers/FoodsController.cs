using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

[Route("api/[controller]")]
public class FoodsController : BaseApi
{
    private readonly IBaseServices<Food> _foodServices;
    private readonly DbContext _dbContext;
    public FoodsController(IMapper mapper, IBaseServices<Food> foodServices, DbContext dbContext) : base(mapper)
    {
        _foodServices = foodServices;
        _dbContext = dbContext;
    }

    #region Queries
    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        var foods = await _foodServices.Query(x => !x.IsDeleted)
                                        .Where(x => !x.FoodCategory.IsDeleted)
                                        .Include(x => x.FoodCategory)
                                        .ProjectTo<FoodResponseDTO>(_mapper.ConfigurationProvider)
                                        .ToListAsync();
        return Success<IList<FoodResponseDTO>>(data: await _foodServices.GetAllAsync<FoodResponseDTO>(filter: x => !x.IsDeleted, includeEntities: x => x.FoodCategory));
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        Food food = await _foodServices.Query(x => x.Id == id && !x.IsDeleted, includeEntities: x => x.FoodCategory).FirstOrDefaultAsync();
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
        Food food = await _foodServices.Find(filter: x => x.Id == id);
        if (food is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        request.Id = id;
        food = _mapper.Map(request, food);
        await _foodServices.Update(food);

        return Success(message: Constants.Transactions.Messages.UpdateComplete);
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        Food food = await _foodServices.Find(filter: x => x.Id == id);

        await _dbContext.Entry(food).Collection(x => x.BookingDetails).LoadAsync();
        if (food.BookingDetails.Count > 0)
        {
            throw new DomainException(Constants.Transactions.Messages.DeleteFailure);
        }

        return Success(message: await _foodServices.Delete(food));
    }
    #endregion
}
