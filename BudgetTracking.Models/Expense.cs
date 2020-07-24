using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetTracking.Models
{
    public class Expense : Shared
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public DateTimeOffset Date { get; set; }
        public Guid? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public Guid? CorporateID { get; set; }
        public virtual Corporate Corporate { get; set; }
        public Guid? UserID { get; set; }
        public virtual User User { get; set; }
        public Guid? MemberID { get; set; }
        public virtual Member Member { get; set; }
    }
}
