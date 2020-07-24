using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.Models
{
    public class ReportData
    {
        public string Date { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public double Value { get; set; }
    }
}
