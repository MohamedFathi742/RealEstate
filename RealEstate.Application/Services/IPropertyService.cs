using RealEstate.Application.DTOs.Requests;
using RealEstate.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Services;
public interface IPropertyService
{
    Task<IEnumerable<PropertyResponse>> GetAllPropertiesAsync();
    Task<PropertyResponse?> GetPropertyByIdAsync(int id);
    Task<PropertyResponse> CreatePropertyAsync(CreatePropertyRequest request );
    Task<PropertyResponse> UpdatePropertyAsync(int id,UpdatePropertyRequest request);
    Task DeletePropertyAsync(int id);


}
