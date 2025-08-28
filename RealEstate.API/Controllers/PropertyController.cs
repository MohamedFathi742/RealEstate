using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs.Requests;
using RealEstate.Application.Services;

namespace RealEstate.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PropertyController(IPropertyService propertyService) : ControllerBase
{
    private readonly IPropertyService _propertyService = propertyService;

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllProperties() 
    {
    var properties=await _propertyService.GetAllPropertiesAsync();
        return Ok(properties);
    
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProertyById(int id)
    {
    if(!ModelState.IsValid)return BadRequest(ModelState);

    var property=await _propertyService.GetPropertyByIdAsync(id);

        if(property is null)return NotFound();

        return Ok(property);

    }

    [HttpPost("")]
    public async Task<IActionResult> AddProperty([FromBody] CreatePropertyRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var addProperty = await _propertyService.CreatePropertyAsync(request);
        return Ok(addProperty);


    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateProperty([FromBody]UpdatePropertyRequest request,int id ) 
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var updateProperty = await _propertyService.UpdatePropertyAsync(id, request );

        if(updateProperty is null)return NotFound();

        return Ok(updateProperty);

    }

    [HttpDelete("{id}")]
    public async Task< IActionResult> DeleteProperty(int id)
    {
        var property = await _propertyService.GetPropertyByIdAsync(id);
        if (property is null) return NotFound();
        var deleteProperty =  _propertyService.DeletePropertyAsync(id);
       
    return NoContent();
    
    }

}
