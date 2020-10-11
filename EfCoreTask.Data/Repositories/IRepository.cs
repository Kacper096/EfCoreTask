using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EfCoreTask.Data.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Delete(Guid id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity model);
        void Update(TEntity model);
    }
}
