using FluentValidation;
using RealEstate.Application.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Validatores;
public class LoginUserValidator:AbstractValidator<LoginUserRequest>
{
    public LoginUserValidator()
    {
        RuleFor(u => u.Email).NotEmpty().EmailAddress();
        RuleFor(u => u.Password).NotEmpty().MinimumLength(8);
    }
}
