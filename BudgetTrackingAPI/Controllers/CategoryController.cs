using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BudgetTracking.DTOs;
using BudgetTracking.Repositories.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(IRepositoryWrapper repoWrapper, IMapper mapper) : base(repoWrapper, mapper) { }
        [HttpGet]
        public ActionResult<List<LiteCategoryDTO>> Get()
        {
            return Ok(mapper.Map<IEnumerable<LiteCategoryDTO>>(repoWrapper.Category.Get().ToList()));
        }
    }
}