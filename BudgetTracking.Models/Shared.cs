using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetTracking.Models
{
    public class Shared
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
