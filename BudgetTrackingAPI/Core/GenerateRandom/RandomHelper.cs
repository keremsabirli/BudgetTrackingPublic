using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTrackingAPI.Core.GenerateRandom
{
    public class RandomHelper
    {
        public DateTimeOffset RandomDate(DateTimeOffset startDate, int dayRange)
        {
            Random rand = new Random();
            return startDate.AddDays(rand.Next(dayRange));
        }
    }
}
