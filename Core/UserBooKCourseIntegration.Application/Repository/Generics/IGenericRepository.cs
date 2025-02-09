using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq.Expressions;
using UserBooKCourseIntegration.Domain.Models.Abstract;

namespace UserBooKCourseIntegration.Application.Repository.Generics;

public interface IGenericRepository<T> where T: class,IEntity,new()
{
    DbSet<T> Table { get; }
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
    Task<T> GetByIdAsync(int id);
    Task<bool>AddAsync(T entity);
    Task<bool> RemoveAsync(int id);
    Task<bool> UpdateAsync(T Entity);
    Task<int> SaveAsync();
}
