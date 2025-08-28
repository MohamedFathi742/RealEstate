using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Interfaces;
using RealEstate.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories;
public class GenericRepository<T> (ApplicationDbContext context): IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = context;
    private readonly DbSet<T> _dbset = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync()=>await _dbset.ToListAsync();
    

    public async Task<T?> GetByIdAsync(int id)=>await _dbset.FindAsync(id);
    

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)=>await _dbset.Where(predicate).ToListAsync();



    public async Task AddAsync(T entity)
    {
        await _dbset.AddAsync(entity);
         await _context.SaveChangesAsync();
    }

    public async Task UpdatAesync(T entity)
    {
        _dbset.Update(entity);
        await _context.SaveChangesAsync();
      
    }

    public async Task RemoveAsync(T entity)
    {
        

        _dbset.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()=>await _context.SaveChangesAsync();

   
    
}
