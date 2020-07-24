using Microsoft.EntityFrameworkCore;
using BudgetTracking.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using BudgetTracking.Repositories.Interfaces;
using BudgetTracking.Context;

namespace BudgetTracking.Repositories
{
    public class BaseRepository<T>:IRepository<T>
        where T : Shared

    {
        readonly BudgetTrackingDBContext budgetTrackingContext;
        protected DbSet<T> Table { get; set; }
        public BaseRepository(BudgetTrackingDBContext context)
        {
            budgetTrackingContext = context;
            Table = budgetTrackingContext.Set<T>();
        }
        public IQueryable<T> Get()
        {
            return Table;
        }

        public T Get(Guid id)
        {
            return Table.FirstOrDefault(x => x.Id == id);
        }
        public T GetById(Guid id)
        {
            return Table.Find(id);
        }
        public IQueryable<T>GetByCondition(Expression<Func<T,bool>>predicate)
        {
            return Table.Where(predicate);

        }
        public bool Insert (T entity)
        {
            Table.Add(entity);
            return Save();
        }
        public bool Update(T entity)
        {
            Table.Update(entity);
            return Save();
        }
        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return Save();
        }
        public bool Save()
        {
            try
            {
                budgetTrackingContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    
}

