using BudgetTracking.Models;
using BudgetTracking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.Repositories.Wrappers
{
    public interface IRepositoryWrapper
    {
        IRepository<Corporate> Corporate { get; }
        IRepository<Category> Category { get; }
        IRepository<Expense> Expense { get; }
        IRepository<PaymentMethod> PaymentMethod { get; }
        IRepository<Member> Member { get; }
        IRepository<User> User { get; }

        void Save();
    }
}
