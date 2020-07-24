using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetTracking.Models
{
    public class Corporate : Shared
    {
        public string Name { get; set; }
        public Guid? UserID { get; set; }
        public string IconUrl { get; set; }
        public virtual User User { get; set; }
    }
}
