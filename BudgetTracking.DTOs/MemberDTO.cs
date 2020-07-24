using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.DTOs
{
    public class LiteMemberDTO : SharedDTO
    {
        public string Name { get; set; }
        public Guid? UserID { get; set; }
    }
    public class MemberDTO : LiteMemberDTO
    {
        public UserDTO User { get; set; }
    }
}
