using BudgetTracking.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTrackingAPI.Core.Date
{
    public class DateHelper
    {
        public int GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return (date - firstMonthMonday).Days / 7 + 1;
        }
        public string GenerateDayString(DateTimeOffset date)
        {
            string yearString = date.Year.ToString();
            string minimalYearString = yearString.Substring(1, yearString.Length - 1);
            minimalYearString = minimalYearString.Remove(0, 1);
            string dayName = "";
            dayName += (date.Day + " ");
            dayName += (((Month)date.Month) + " ");
            dayName += minimalYearString;
            return dayName;
        }
        public string GenerateWeekString(DateTimeOffset date)
        {
            string weekName = "";
            weekName += (GetWeekNumberOfMonth(date.DateTime) + "th Week ");
            weekName += (((Month)date.Month) + " ");
            string yearString = date.Year.ToString();
            string minimalYearString = yearString.Substring(1, yearString.Length - 1);
            minimalYearString = minimalYearString.Remove(0, 1);
            weekName += minimalYearString;
            return weekName;
        }
        public string GenerateMonthString(DateTimeOffset date)
        {
            string monthName = "";
            monthName += (Month)date.Month + " ";
            monthName += date.Year;
            return monthName;
        }
    }
}
