using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetTracking.Models
{
    public class Member : Shared
    {
        public string Name { get; set; }
        public Guid? UserID { get; set; }
        public virtual User User { get; set; }
    }
}
