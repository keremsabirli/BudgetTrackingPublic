using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.DTOs
{
    public class LitePaymentMethodDTO : SharedDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? UserID { get; set; }
    }
    public class PaymentMethodDTO : LitePaymentMethodDTO
    {
        public UserDTO User { get; set; }
    }
}
