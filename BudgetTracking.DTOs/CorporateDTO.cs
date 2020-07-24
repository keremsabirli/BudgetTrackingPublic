using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.DTOs
{
    public class LiteCorporateDTO : SharedDTO
    {

        public string Name { get; set; }
        public Guid? UserID { get; set; }
        public Guid? CorporateTypeID { get; set; }
        public string IconUrl { get; set; }
    }
    public class CorporateDTO : LiteCorporateDTO
    {
        public UserDTO User { get; set; }
        public CorporateTypeDTO CorporateType { get; set; }
    }
}
