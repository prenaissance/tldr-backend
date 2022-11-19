namespace TLDR.Domain.Entities.Common.Abstractions;

public interface IRepository<T> where T : BaseEntity<Guid>
{
    Task<T?> GetByIdAsync(Guid id);
    IQueryable<T> GetAll();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}