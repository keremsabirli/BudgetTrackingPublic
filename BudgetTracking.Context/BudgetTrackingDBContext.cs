using BudgetTracking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.Context
{
    public class BudgetTrackingDBContext : DbContext
    {
        public BudgetTrackingDBContext(DbContextOptions<BudgetTrackingDBContext> options) : base(options)
        {

        }
        public DbSet<Corporate> Corporate { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Corporate
            modelBuilder.Configure<Corporate>();
            modelBuilder.Entity<Corporate>(b =>
            {
            });

            //Expense
            modelBuilder.Configure<Expense>();
            modelBuilder.Entity<Expense>(b =>
            {
                b.HasOne(x => x.Corporate).WithMany().HasForeignKey(x => x.CorporateID);
                b.HasOne(x => x.Member).WithMany().HasForeignKey(x => x.MemberID);
            });

            //Payment Method
            modelBuilder.Configure<PaymentMethod>();

            //Category
            modelBuilder.Configure<Category>();

            //Member
            modelBuilder.Configure<Member>();
            modelBuilder.Entity<Member>(b =>
            {
                b.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserID);
            });

            //User
            modelBuilder.Configure<User>();
        }
    }
    
}
