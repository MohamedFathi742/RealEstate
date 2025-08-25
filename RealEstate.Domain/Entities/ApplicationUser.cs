using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities;
public sealed class ApplicationUser:IdentityUser
{
  public  string FullName { get; set; }=string.Empty;

    public ICollection<Property> Properties { get; set; }=new  List<Property>();
}
