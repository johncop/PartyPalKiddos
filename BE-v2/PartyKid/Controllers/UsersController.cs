using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PartyKid;

[Route("api/[controller]")]
public class UsersController : BaseApi
{
    private readonly IUserServices _userServices;

    public UsersController(IUserServices userServices, IMapper mapper) : base(mapper)
    {
        _userServices = userServices;
    }

    #region Query
    [Authorize(nameof(RoleCollection.Admin))]
    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        return Success<IList<UserDTO>>(data: await _userServices.GetAll());
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IResponse> Get([FromRoute(Name = "Id")] int id)
    {
        ApplicationUser user = await _userServices.GetById(id.ToString());
        return Success<UserDTO>(data: _mapper.Map<UserDTO>(user));
    }

    [Authorize]
    [HttpGet]
    [Route("current")]
    public async Task<IResponse> GetCurrentUser()
    {
        return Success<UserDTO>(data: _mapper.Map<UserDTO>(await _userServices.GetCurrentUser()));
    }
    #endregion

    #region Command

    [HttpPost]
    [Route("forgot-password")]
    public async Task<IResponse> ForgotPassword([FromBody] ForgotPasswordBindingModel request)
    {
        if (string.IsNullOrEmpty(request.Email))
        {
            throw new DomainException(Constants.UserHandling.Messages.EmailEmpty);
        }
        return Success(message: await _userServices.ForgotPassword(request.Email));
    }

    [Authorize]
    [HttpPut]
    public async Task<IResponse> Update([FromBody] UpdateUserBindingModel request)
    {
        UserDTO currUser = await _userServices.GetCurrentUser();
        UserDTO user = await _userServices.Update(currUser.Id.ToString(), request);
        return Success<UserDTO>(data: user);
    }
    #endregion
}