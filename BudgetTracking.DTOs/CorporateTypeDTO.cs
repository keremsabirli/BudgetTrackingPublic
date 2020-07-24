using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.DTOs
{
    public class LiteCorporateTypeDTO : SharedDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? UserID { get; set; }
        public string Icon { get; set; }
    }
    public class CorporateTypeDTO : LiteCorporateTypeDTO
    {
        public UserDTO User { get; set; }
    }
}
