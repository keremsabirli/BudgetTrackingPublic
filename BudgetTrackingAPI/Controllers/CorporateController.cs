using AutoMapper;
using BudgetTracking.DTOs;
using BudgetTracking.Models;
using BudgetTracking.Repositories.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateController : BaseController
    {
        public CorporateController(IRepositoryWrapper repoWrapper, IMapper mapper) : base(repoWrapper, mapper) { }
        [HttpGet]
        public ActionResult<List<LiteCorporateDTO>> Get(Guid? userId)
        {
            if (userId == null) return Ok(mapper.Map<IEnumerable<LiteCorporateDTO>>(repoWrapper.Corporate.Get().ToList()));
            return Ok(mapper.Map<IEnumerable<LiteCorporateDTO>>(repoWrapper.Corporate.GetByCondition(x => x.UserID == BudgetTrackingUserResult.Id).ToList()));
        }
        [HttpPost]
        public ActionResult<CorporateDTO> Post([FromBody] LiteCorporateDTO value)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (value == null) return BadRequest();
            try
            {
                repoWrapper.Corporate.Insert(mapper.Map<Corporate>(value));
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var entity = repoWrapper.Corporate.GetById(id);
            if (entity == null) return BadRequest("Value with the given id is null");
            repoWrapper.Corporate.Delete(entity);
            repoWrapper.Save();
            return Ok();
        }
    }
}
