using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BudgetTracking.Context;
using BudgetTracking.Models;
using BudgetTracking.Repositories.Interfaces;
using BudgetTracking.Repositories.Repositories;

namespace BudgetTracking.Repositories.Wrappers
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BudgetTrackingDBContext budgetTrackingDBContext;
        public RepositoryWrapper(BudgetTrackingDBContext budgetTrackingDBContext)
        {
            this.budgetTrackingDBContext = budgetTrackingDBContext;
            corporate = new Lazy<IRepository<Corporate>>(() => new CorporateRepository(budgetTrackingDBContext));
            category = new Lazy<IRepository<Category>>(() => new CategoryRepository(budgetTrackingDBContext));
            expense = new Lazy<IRepository<Expense>>(() => new ExpenseRepository(budgetTrackingDBContext));
            paymentMethod = new Lazy<IRepository<PaymentMethod>>(() => new PaymentMethodRepository(budgetTrackingDBContext));
            member = new Lazy<IRepository<Member>>(() => new MemberRepository(budgetTrackingDBContext));
            user = new Lazy<IRepository<User>>(() => new UserRepository(budgetTrackingDBContext));
            category = new Lazy<IRepository<Category>>(() => new CategoryRepository(budgetTrackingDBContext));
        }

        private Lazy<IRepository<Corporate>> corporate;
        private Lazy<IRepository<Category>> category;
        private Lazy<IRepository<Expense>> expense;
        private Lazy<IRepository<PaymentMethod>> paymentMethod;
        private Lazy<IRepository<Member>> member;
        private Lazy<IRepository<User>> user;

        public IRepository<Corporate> Corporate => corporate.Value;

        public IRepository<Category> Category => category.Value;

        public IRepository<Expense> Expense => expense.Value;

        public IRepository<PaymentMethod> PaymentMethod => paymentMethod.Value;

        public IRepository<Member> Member => member.Value;

        public IRepository<User> User => user.Value;

        public void Save()
        {
            budgetTrackingDBContext.SaveChanges();
        }
    }
}
