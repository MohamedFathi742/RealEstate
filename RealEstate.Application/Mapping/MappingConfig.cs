using Mapster;
using RealEstate.Application.DTOs.Requests;
using RealEstate.Application.DTOs.Responses;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Mapping;
public static class MappingConfig
{
    public static void RegisterMappings() 
    {
        TypeAdapterConfig<CreatePropertyRequest, Property>.NewConfig()
            .Map(dest=>dest.ImagePath,src=> 
            string.IsNullOrWhiteSpace(src.Image)
                ? "default.png"   
                : src.Image);
        TypeAdapterConfig<UpdatePropertyRequest, Property>.NewConfig();
        TypeAdapterConfig<Property, PropertyResponse>.NewConfig();
    
    
        TypeAdapterConfig<RegesterUserRequest, ApplicationUser>.NewConfig();
        TypeAdapterConfig<ApplicationUser, UserResponse>.NewConfig();
           
    
    
    
    }
}
