using Microsoft.AspNetCore.Mvc;

using UserInfo.Models.Requests;
using UserInfo.Services;

namespace UserInfo.Controllers;


public class UserInfoController(IUserInfoService service) : ControllerBase
{

    public async Task<IActionResult> Create(UserInfoRequest request)
    {
        await service.CreateUser(request);
        return Ok("created");
    }

    
    public async Task<IActionResult> GetById(int userId)
    {
        var response = await service.GetUserById(userId);
        return Ok(response);
    }
    
    
    public async Task<IActionResult> GetAll()
    {
        var response = await service.GetAll();
        return Ok(response);
    }
    
}