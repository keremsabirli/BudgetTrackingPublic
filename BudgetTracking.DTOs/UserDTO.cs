using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.DTOs
{
    public class LiteUserDTO : SharedDTO
    {
        public string Name { get; set; }
        public string MailAddress { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
    public class UserDTO : LiteUserDTO
    {

    }
}
