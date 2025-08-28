using RealEstate.Application.DTOs.Requests;
using RealEstate.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Services;
public interface IUserService
{
    Task<UserResponse> RegisterAsync(RegesterUserRequest request,string role);
    Task<UserResponse> LoginAsync(LoginUserRequest request);

}
