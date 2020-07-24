using BudgetTracking.Context;
using BudgetTracking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.Repositories.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(BudgetTrackingDBContext context) : base(context)
        {
        }
    }
}
