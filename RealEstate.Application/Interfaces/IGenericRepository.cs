using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task< IEnumerable<T>> GetAllAsync(); 
    Task <T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T,bool>>predicate);
    Task AddAsync(T entity);
    void Updatesync(T entity);
    void RemoveAsync(T entity);
    Task SaveChangesAsync();


}
