using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly OrderContext _context;

    public RepositoryBase(OrderContext context)
    {
        _context = context;
    }

    public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ?
        _context.Set<T>().AsNoTracking() : _context.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ?
        _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);

    public void Create(T entity) => _context.Set<T>().Add(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);
}