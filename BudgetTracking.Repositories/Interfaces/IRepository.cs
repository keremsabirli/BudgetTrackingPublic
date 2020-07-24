using System;
using System.Linq;
using System.Linq.Expressions;

namespace BudgetTracking.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        IQueryable<T> GetByCondition(Expression<Func<T,bool>> predicate);
        T Get(Guid id);
        T GetById(Guid id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);

    }
}
