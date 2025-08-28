using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs.Requests;
using RealEstate.Application.DTOs.Responses;
using RealEstate.Application.Services;

namespace RealEstate.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;


    [HttpPost("register")]
    public async Task<ActionResult<UserResponse>> Register([FromBody] RegesterUserRequest request, [FromQuery] string role = "User")
    {
        if (!ModelState.IsValid)

            return BadRequest(ModelState);

        var result = await _userService.RegisterAsync(request, role); return Ok(result);

    }


    [HttpPost("login")]
    public async Task<ActionResult<UserResponse>> Login([FromBody] LoginUserRequest request)
    {
        if (!ModelState.IsValid)

            return BadRequest(ModelState);


        var result = await _userService.LoginAsync(request); return Ok(result);


    }


}
