using System.Net.Sockets;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;


[Route("api/[controller]")]
public class CombosController : BaseApi
{
    private readonly IBaseServices<Combo> _comboServices;
    public CombosController(IMapper mapper, IBaseServices<Combo> comboServices) : base(mapper)
    {
        _comboServices = comboServices;
    }

    #region Queries

    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        IList<ComboResponseDTO> combos = await _comboServices.GetAllAsync<ComboResponseDTO>(filter: x => !x.IsDeleted, includeEntities: x => x.ComboFoods);
        return Success<IList<ComboResponseDTO>>(data: combos);
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        Combo combo = await _comboServices.Query(filter: x => x.Id == id && !x.IsDeleted, includeEntities: x => x.ComboFoods).FirstOrDefaultAsync();
        if (combo is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }
        return Success<ComboResponseDTO>(data: _mapper.Map<ComboResponseDTO>(combo));
    }

    [HttpGet]
    [Route("search")]
    public async Task<IResponse> Search()
    {
        return Success();
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
        Combo combo = await _comboServices.Query(filter: x => x.Id == id)
                                            .Include(x => x.ComboFoods)
                                            .ThenInclude(x => x.Food)
                                            .FirstOrDefaultAsync();
        if (combo is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        request.Id = id;
        combo = _mapper.Map(request, combo);

        if (request.ComboFoods is not null && request.ComboFoods.Count > 0)
        {
            combo.ComboFoods = combo.ComboFoods.Count <= 0 ? new List<ComboFood>() : combo.ComboFoods;
            foreach (var comboFood in request.ComboFoods)
            {
                combo.ComboFoods.Add(new ComboFood()
                {
                    FoodId = comboFood.FoodId
                });
            }
        }

        ComboResponseDTO comboUpdated = _mapper.Map<ComboResponseDTO>(await _comboServices.Update(combo));
        return Success<ComboResponseDTO>(data: comboUpdated);
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IResponse> Delete([FromRoute(Name = "Id")] int id)
    {
        Combo combo = await _comboServices.Find(id);
        if (combo is null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        return Success(message: await _comboServices.Delete(id));
    }
    #endregion
}
