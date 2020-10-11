using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTask.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            var entity = _context.Set<TEntity>().Find(id) ?? throw new NullReferenceException();

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>()
                .Where(expression)
                .ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public void Insert(TEntity model)
        {
            _context.Set<TEntity>().Add(model);
            _context.SaveChanges();
        }

        public void Update(TEntity model)
        {
            _context.Set<TEntity>().Update(model);
            _context.SaveChanges();
        }
    }
}
