using AutoMapper;
using BudgetTracking.Models;
using BudgetTracking.Repositories.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected IRepositoryWrapper repoWrapper;
        protected IMapper mapper;
        protected User BudgetTrackingUserResult { get; set; }
        public BaseController(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            this.repoWrapper = repoWrapper;
            this.mapper = mapper;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(Request.Headers.ContainsKey("Key") && Request.Headers["Key"].Any())
            {
                string authToken = ResolveAuthorization(Request.Headers["Key"].FirstOrDefault());
                BudgetTrackingUserResult = repoWrapper.User.GetByCondition(x => x.HashedPassword == authToken).FirstOrDefault();
                if(BudgetTrackingUserResult == null)
                {
                    context.Result = BadRequest("User Not Found.");
                    return;
                }
            }
            await base.OnActionExecutionAsync(context, next);
        }

        protected virtual string ResolveAuthorization(string authHeader)
        {
            if (string.IsNullOrEmpty(authHeader)) return string.Empty;
            return authHeader;
        }
    }
}
