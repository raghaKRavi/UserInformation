using Microsoft.AspNetCore.Mvc;

using UserInfo.Models.Requests;
using UserInfo.Services;

namespace UserInfo.Controllers;

[Route("api/userinfo")]
[ApiController]
public class UserInfoController(IUserInfoService service) : ControllerBase
{
    //private readonly IUserInfoService _service = service;
    
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(UserInfoRequest request)
    {
        await service.CreateUser(request);
        return Ok("created");
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(int userId)
    {
        var response = await service.GetUserById(userId);
        return Ok(response);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var response = await service.GetAll();
        return Ok(response);
    }
    
}