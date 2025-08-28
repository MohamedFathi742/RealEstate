using FluentValidation;
using RealEstate.Application.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Validatores;
public class UpdatePropertyValidator:AbstractValidator<UpdatePropertyRequest>
{
    public UpdatePropertyValidator()
    {
        RuleFor(p => p.Title).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Location).NotEmpty();
    }
}
