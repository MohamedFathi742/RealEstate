using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.DTOs.Requests;
public class CreatePropertyRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Location { get; set; } = string.Empty;
    public string? Image { get; set; }
    public string OwnerId { get; set; } = string.Empty;
    public string GetImageOrDefault()
       => string.IsNullOrWhiteSpace(Image) ? "default.png" : Image;
}