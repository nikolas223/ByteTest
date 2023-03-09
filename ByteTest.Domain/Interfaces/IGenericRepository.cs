namespace ByteTest.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    //DbSet<T> GetAll();
    Task<List<T>> ListAsync(string? navigationProperty = null);
    Task<T?> GetByIdOrDefault(int id);
    void Add(T entity);
    void AddRange(List<T> entities);
    void Update(T entity);
    void Delete(T entity);
}