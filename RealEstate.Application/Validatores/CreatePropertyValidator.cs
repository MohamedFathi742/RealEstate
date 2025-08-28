using FluentValidation;
using RealEstate.Application.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Validatores;
public class CreatePropertyValidator:AbstractValidator<CreatePropertyRequest>
{
    public CreatePropertyValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(p => p.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price Should be Greater Than 0");
        RuleFor(p => p.Location).NotEmpty().WithMessage("Location is required.");
    }
}
