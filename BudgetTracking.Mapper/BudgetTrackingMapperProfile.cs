using AutoMapper;
using BudgetTracking.DTOs;
using BudgetTracking.Models;
using BudgetTracking.Models.IncomingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracking.Mapper
{
    public class BudgetTrackingMapperProfile : Profile
    {
        public BudgetTrackingMapperProfile()
        {
            //Corporate
            //Lite
            CreateMap<Corporate, LiteCorporateDTO>().ReverseMap();
            //Standard
            CreateMap<Corporate, CorporateDTO>().IncludeBase<Corporate, LiteCorporateDTO>().ReverseMap();

            //CorporateType
            //Lite
            CreateMap<Category, LiteCategoryDTO>().ReverseMap();

            //Expense
            //Lite
            CreateMap<Expense, LiteExpenseDTO>().ReverseMap();
            //Standard
            CreateMap<Expense, ExpenseDTO>().IncludeBase<Expense, LiteExpenseDTO>().ReverseMap();

            //ExpenseType
            //Lite
            CreateMap<PaymentMethod, LitePaymentMethodDTO>().ReverseMap();
            //Standard
            CreateMap<PaymentMethod, PaymentMethodDTO>().IncludeBase<PaymentMethod, LitePaymentMethodDTO>().ReverseMap();

            //Member
            //Lite
            CreateMap<Member, LiteMemberDTO>().ReverseMap();
            //Standard
            CreateMap<Member, MemberDTO>().IncludeBase<Member, LiteMemberDTO>().ReverseMap();

            //User
            //Lite
            CreateMap<User, LiteUserDTO>().ReverseMap();
            //Standard
            CreateMap<User, UserDTO>().IncludeBase<User, LiteUserDTO>().ReverseMap();
        }
    }
}
