using BudgetTracking.Context;
using BudgetTracking.Models;
using BudgetTracking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracking.Repositories
{
    public class ExpenseRepository : BaseRepository<Expense>, IRepository<Expense>
    {
        public ExpenseRepository(BudgetTrackingDBContext context) : base(context)
        {

        }
    }
}