using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BudgetTracking.DTOs;
using BudgetTracking.Models;
using BudgetTracking.Repositories.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : BaseController
    {
        public MemberController(IRepositoryWrapper repoWrapper, IMapper mapper) : base(repoWrapper, mapper) { }
        [HttpGet]
        public ActionResult<List<MemberDTO>> Get()
        {
            return Ok(mapper.Map<IEnumerable<MemberDTO>>(repoWrapper.Member.GetByCondition(x => x.UserID == BudgetTrackingUserResult.Id).ToList()));
        }
        [HttpPost]
        public ActionResult<MemberDTO> Post([FromBody] LiteMemberDTO value)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (value == null) return BadRequest();
            try
            {
                repoWrapper.Member.Insert(mapper.Map<Member>(value));
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
            var entity = repoWrapper.Member.GetById(id);
            if (entity == null) return BadRequest("Value with the given id is null");
            repoWrapper.Member.Delete(entity);
            repoWrapper.Save();
            return Ok();
        }
    }
}