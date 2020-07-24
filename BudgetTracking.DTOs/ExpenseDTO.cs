using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.DTOs
{
    public class LiteExpenseDTO : SharedDTO
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public DateTimeOffset Date { get; set; }
        public Guid? CorporateID { get; set; }
        public Guid? MemberID { get; set; }
        public Guid? UserID { get; set; }
    }
    public class ExpenseDTO : LiteExpenseDTO
    {
        public CorporateDTO Corporate { get; set; }
        public MemberDTO Member { get; set; }
        public UserDTO User { get; set; }
    }
}
