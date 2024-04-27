using System.Net.Sockets;
using System.Reflection.Metadata;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PartyKid;


[Route("api/[controller]")]
public class CombosController : BaseApi
{
    private readonly IBaseServices<Combo> _comboServices;
    private readonly PartyKidDbContext _dbContext;
    public CombosController(IMapper mapper, IBaseServices<Combo> comboServices, PartyKidDbContext dbContext) : base(mapper)
    {
        _comboServices = comboServices;
        _dbContext = dbContext;
    }

    #region Queries

    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        var combos = await _comboServices.Query(x => !x.IsDeleted)
                                            .Include(x => x.ComboFoods)
                                            .ProjectTo<ComboResponseDTO>(_mapper.ConfigurationProvider)
                                            .ToListAsync();
        return Success<IList<ComboResponseDTO>>(data: combos);
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        Combo combo = await _comboServices.Query(filter: x => x.Id == id && !x.IsDeleted)
                                        .Include(x => x.ComboFoods)
                                        .AsTracking()
                                        .FirstOrDefaultAsync();
        if (combo is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        await _dbContext.Entry(combo).Collection(x => x.ComboFoods).Query().Include(x => x.Food).ThenInclude(x => x.FoodCategory).LoadAsync();
        return Success<ComboResponseDTO>(data: _mapper.Map<ComboResponseDTO>(combo));
    }

    #endregion

    #region Commands

    [Authorize(nameof(RoleCollection.Admin))]
    [HttpPost]
    public async Task<IResponse> Create([FromBody] AddComboBindingModel request)
    {
        Combo combo = _mapper.Map<Combo>(request);
        if (request.ComboFoods is not null && request.ComboFoods.Count > 0)
        {
            combo.ComboFoods = new List<ComboFood>();
            foreach (var comboFood in request.ComboFoods)
            {
                combo.ComboFoods.Add(new ComboFood()
                {
                    FoodId = comboFood.FoodId
                });
            }
        }

        return Success(message: await _comboServices.Create(combo));
    }

    [HttpPut]
    [Route("{Id}")]
    public async Task<IResponse> Update([FromRoute(Name = "Id")] int id, [FromBody] UpdateComboBindingModel request)
    {
        Combo combo = await _comboServices.Query(filter: x => x.Id == id).AsTracking().FirstOrDefaultAsync();
        if (combo is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        await _dbContext.Entry(combo).Collection(x => x.ComboFoods).Query().Include(x => x.Food).ThenInclude(x => x.FoodCategory).LoadAsync();

        request.Id = id;

        if (request.Foods is not null && request.Foods.Count > 0)
        {
            combo.ComboFoods = combo.ComboFoods.Count <= 0 ? new List<ComboFood>() : combo.ComboFoods;
            foreach (var foodId in request.Foods)
            {
                ComboFood comboFoodExisted = combo.ComboFoods.FirstOrDefault(x => x.FoodId == foodId);
                if (comboFoodExisted is null)
                {
                    combo.ComboFoods.Add(new ComboFood()
                    {
                        FoodId = foodId
                    });
                }
            }
        }

        combo = _mapper.Map(request, combo);
        await _comboServices.Update(combo);
        return Success(message: Constants.Transactions.Messages.UpdateComplete);
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        Combo combo = await _comboServices.Find(filter: x => x.Id == id);
        if (combo is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        return Success(message: await _comboServices.DeleteAsync(combo));
    }
    #endregion
}
