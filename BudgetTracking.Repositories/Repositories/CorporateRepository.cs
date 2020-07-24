using BudgetTracking.Context;
using BudgetTracking.Models;
using BudgetTracking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracking.Repositories
{
    public class CorporateRepository : BaseRepository<Corporate>, IRepository<Corporate>
    {
        public CorporateRepository(BudgetTrackingDBContext context): base(context)
        {

        }
    }
}
