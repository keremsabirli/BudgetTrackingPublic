using BudgetTracking.Context;
using BudgetTracking.Models;
using BudgetTracking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracking.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IRepository<Member>
    {
        public MemberRepository(BudgetTrackingDBContext context) : base(context)
        {

        }
    }
}