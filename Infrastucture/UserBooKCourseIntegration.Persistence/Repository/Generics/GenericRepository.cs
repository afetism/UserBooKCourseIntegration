using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using UserBooKCourseIntegration.Application.Repository.Generics;
using UserBooKCourseIntegration.Domain.Models.Abstract;
using UserBooKCourseIntegration.Persistence.Data;

namespace UserBooKCourseIntegration.Persistence.Repository.Generics;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
{
    private readonly LibraryDbContext _dbContext;

    public GenericRepository(LibraryDbContext libraryDbContext)
    {
        _dbContext = libraryDbContext;
    }

    public DbSet<T> Table => _dbContext.Set<T>();

    public async Task<bool> AddAsync(T entity)
    {
        await _dbContext.AddAsync(entity);
        return await SaveAsync() > 0;
    }

    public IQueryable<T> GetAll() => Table;

    public async Task<T> GetByIdAsync(int id)
    {
        return await Table.FindAsync(id);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
    {
        return Table.Where(method);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var entity = await Table.FindAsync(id);
        if (entity == null)
        {
            return false;
        }
        _dbContext.Remove(entity);
        return await SaveAsync() > 0;
    }

    public async Task<int> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        var existingEntity = await Table.FindAsync(entity.Id);
        if (existingEntity == null)
        {
            return false;
        }
        _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        return await SaveAsync() > 0;
    }
}
