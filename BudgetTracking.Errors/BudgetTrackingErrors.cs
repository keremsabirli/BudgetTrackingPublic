using System;

namespace BudgetTracking.Errors
{
    public static class BudgetTrackingErrors
    {
        public static class AuthErrors
        {
            public const string MailAddressNotFound = "Mail Address not found.";
            public const string WrongPassword = "Wrong Password";
            public const string MailAlreadyRegistered = "Mail Address already registered";
        }
        public static class ExpenseErrors
        {
            public const string StartDateMoreRecentThanEndDate = "Start date is more recent than end date.";
            public const string EndDateWithoutStartDate = "End Date given without Start date.";
        }
    }
}
