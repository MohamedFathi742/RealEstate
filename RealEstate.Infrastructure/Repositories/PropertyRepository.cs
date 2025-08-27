using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories;
public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
{
    private readonly ApplicationDbContext _context ;
    public PropertyRepository(ApplicationDbContext context) : base(context) => _context = context;
    public async Task<IEnumerable<Property>> GetPropertiesBuOwner(string ownerId)
    {
      return await _context.Properties
            .Where(p=>p.OwnerId==ownerId)
            .ToListAsync();
    }
}
