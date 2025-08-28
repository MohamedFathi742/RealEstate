using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities;
public sealed class Property
{
    public int Id { get; set; }
    public string Title { get; set; }=string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string  Location { get; set; } = string.Empty;
    public string?ImagePath { get; set; }
    public DateTime CreatedAt { get; set; }= DateTime.Now;

    public string OwnerId { get; set; } = string.Empty;
    public ApplicationUser? Owner { get; set; }

}
