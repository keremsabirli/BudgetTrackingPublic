using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetTracking.Models
{
    public class PaymentMethod : Shared
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
