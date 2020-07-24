using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.DTOs
{
    public class SharedDTO
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
