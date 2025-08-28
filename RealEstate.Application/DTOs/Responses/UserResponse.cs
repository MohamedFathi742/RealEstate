﻿namespace RealEstate.Application.DTOs.Responses;
public class UserResponse
{

    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string? Token { get; set; }


}
