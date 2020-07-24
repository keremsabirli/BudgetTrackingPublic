using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetTracking.Models
{
    public class User : Shared
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string MailAddress { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}
