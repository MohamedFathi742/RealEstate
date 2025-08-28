using Mapster;
using RealEstate.Application.DTOs.Requests;
using RealEstate.Application.DTOs.Responses;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Services;
public class PropertyService(IPropertyRepository repository) : IPropertyService
{
    private readonly IPropertyRepository _repository = repository;

    public async Task<IEnumerable<PropertyResponse>> GetAllPropertiesAsync()
    {
        var properties = await _repository.GetAllAsync();
        return properties.Adapt<IEnumerable<PropertyResponse>>();
    }

    public async Task<PropertyResponse?> GetPropertyByIdAsync(int id)
    {
        var property = await _repository.GetByIdAsync(id);
        return property.Adapt<PropertyResponse>();
    }
    public async Task<PropertyResponse> CreatePropertyAsync(CreatePropertyRequest request)
    {
        var property = request.Adapt<Property>();
        property.ImagePath = request.GetImageOrDefault();
        await _repository.AddAsync(property);
        return property.Adapt<PropertyResponse>();

    }

    public async Task<PropertyResponse> UpdatePropertyAsync(int id, UpdatePropertyRequest request)
    {
        var property = await _repository.GetByIdAsync(id);

        if (property == null)
            throw new Exception("Property Not Found");
        property.Title = request.Title;
        property.Description = request.Description;
        property.Price = request.Price;
        property.Location = request.Location;
        if (!string.IsNullOrEmpty(request.ImagePath))
        {
            property.ImagePath = request.ImagePath;   
        }

        await _repository.UpdatAesync(property);
        return property.Adapt<PropertyResponse>();

    }
    public async Task DeletePropertyAsync(int id)
    {
        var property=await _repository.GetByIdAsync(id);
        if (property == null)
            throw new Exception("Property Not Found");
        await _repository.RemoveAsync(property);
    }




}
