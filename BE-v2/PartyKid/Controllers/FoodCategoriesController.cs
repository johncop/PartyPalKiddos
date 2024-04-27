using System.Reflection.Metadata;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/food-categories")]
public class FoodCategoriesController : BaseApi
{
    private readonly IBaseServices<FoodCategory> _foodCategoryServices;
    public FoodCategoriesController(IMapper mapper, IBaseServices<FoodCategory> foodCategoryServices) : base(mapper)
    {
        _foodCategoryServices = foodCategoryServices;
    }

    #region Queries
    [HttpGet]
    public async Task<IResponse> GetAll() => Success<IList<FoodCategoryResponseDTO>>(data:
                                                                    await _foodCategoryServices.GetAllAsync<FoodCategoryResponseDTO>(filter: x => !x.IsDeleted));

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        FoodCategory foodCategory = await _foodCategoryServices.Find(filter: x => x.Id == id);
        return Success<FoodCategoryResponseDTO>(data: _mapper.Map<FoodCategoryResponseDTO>(foodCategory));
    }

    [HttpGet]
    [Route("search/{name}")]
    public async Task<IResponse> Search([FromRoute(Name = "name")] string name)
    {
        return Success<IList<FoodCategoryResponseDTO>>(data: await
                    _foodCategoryServices.GetAllAsync<FoodCategoryResponseDTO>(filter: x => x.Name.ToLower().Contains(name.ToLower())));
    }
    #endregion

    #region Commands
    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] CreateFoodCategoryBindingModel request)
    {
        FoodCategory foodCategory = _mapper.Map<FoodCategory>(request);
        return Success(message: await _foodCategoryServices.Create(foodCategory));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateFoodCategoryBindingModel request)
    {
        FoodCategory foodCategory = await _foodCategoryServices.Find(filter: x => x.Id == id);

        foodCategory = _mapper.Map(request, foodCategory);
        return Success<FoodCategory>(data: await _foodCategoryServices.Update(foodCategory));
    }

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        FoodCategory foodCategory = await _foodCategoryServices.Find(filter: x => x.Id == id);

        foodCategory.Foods.Clear();
        return Success(message: await _foodCategoryServices.Delete(foodCategory));
    }
    #endregion
}
