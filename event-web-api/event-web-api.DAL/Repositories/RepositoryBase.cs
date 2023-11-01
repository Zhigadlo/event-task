using Contracts.Repositories;
using event_web_api.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace event_web_api.DAL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected EventContext _context;

        public RepositoryBase(EventContext context)
        {
            _context = context;
        }
        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ? _context.Set<T>()
                                                                                                         .Where(expression)
                                                                                                         .AsNoTracking() : _context.Set<T>()
                                                                                                         .Where(expression);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
