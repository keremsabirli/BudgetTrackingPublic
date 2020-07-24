using BudgetTracking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Configure<T>(this ModelBuilder self)
            where T : Shared
        {
            self.Entity<T>(b =>
            {
                b.Property(x => x.Id).HasDefaultValueSql("UUID()");
                b.Property(x => x.CreatedDate).HasDefaultValueSql("NOW()");
                b.Property(x => x.IsActive).HasDefaultValue(true);
            });
        }
    }
}
