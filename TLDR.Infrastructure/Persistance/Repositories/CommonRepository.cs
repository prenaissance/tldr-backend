using Microsoft.EntityFrameworkCore;
using TLDR.Domain.Entities.Common.Abstractions;

namespace TLDR.Infrastructure.Persistance.Repositories;

public class CommonRepository<T> : IRepository<T> where T : BaseEntity<Guid>
{
    protected readonly TldrDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public CommonRepository(TldrDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}