using ByteTest.Domain.Implementations;
using ByteTest.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ByteTest.Infrastructure.Persistence;

public abstract class GenericRepository<T>: IGenericRepository<T> where T : Entity
{
    protected readonly ByteTestDbContext Context;
    protected readonly DbSet<T> DbSet;

    public GenericRepository(ByteTestDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public virtual async Task<List<T>> ListAsync(string? navigationProperty = null)
    {
        if (navigationProperty is not null)
        {
            return await DbSet.Include(navigationProperty).OrderBy(x=>x.Id).ToListAsync();
        }

        return await DbSet.OrderBy(x=>x.Id).ToListAsync();
    }
    
    public virtual async Task<T?> GetByIdOrDefault(int id)
    {
        return await DbSet.FirstOrDefaultAsync(x=> x.Id == id);
    }

    public virtual void Add(T entity)
    {
        entity.CreationTime = DateTime.UtcNow;
        DbSet.Add(entity);
    }
    public virtual void AddRange(List<T> entities)
    {
        entities.ForEach(Add);
    }
    
    public virtual void Update(T entity)
    {
        DbSet.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        entity.LastModificationTime = DateTime.UtcNow;
    }

    public virtual void Delete(T entity)
    {
        DbSet.Remove(entity);
    }
}