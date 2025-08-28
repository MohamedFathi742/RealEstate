using Mapster;
using Microsoft.AspNetCore.Identity;
using RealEstate.Application.DTOs.Requests;
using RealEstate.Application.DTOs.Responses;
using RealEstate.Application.Interfaces.Security;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Services;
public class UserService (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IJwtService jwtService) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly IJwtService _jwtService = jwtService;
    public async Task<UserResponse> RegisterAsync(RegesterUserRequest request, string role)
    {
        var user = request.Adapt<ApplicationUser>();
        user.UserName=request.Email;
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new Exception(string.Join(",",result.Errors.Select(e=>e.Description)));

        await _userManager.AddToRoleAsync(user, role);

        var roles=await _userManager.GetRolesAsync(user);

        var token =  _jwtService.GenerateToken(user.Id,user.Email!, roles);

        var res = user.Adapt<UserResponse>();
        res.Role = roles.FirstOrDefault()??string.Empty;
        res.Token = token;
        return res;
    }
    public async Task<UserResponse> LoginAsync(LoginUserRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if(user is null)
            throw new UnauthorizedAccessException("Invalid Credentails");
        var check = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
        if (check is null)
            throw new UnauthorizedAccessException("Invalid Credentails");

        var roles= await _userManager.GetRolesAsync(user);

        var token =  _jwtService.GenerateToken(user.Id, user.Email!, roles);

        return new UserResponse 
        {
        Id= user.Id,
        FullName=user.FullName,
        Email=user.Email!,
        Role=roles.FirstOrDefault()??string.Empty,
        Token=token

        };
            
            

    }

    
}
