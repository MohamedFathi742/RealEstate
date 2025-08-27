using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces;
public interface IPropertyRepository:IGenericRepository<Property>
{

    Task<IEnumerable<Property>> GetPropertiesBuOwner(string ownerId);


}
