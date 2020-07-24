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
    public class PaymentMethodController : BaseController
    {
        public PaymentMethodController(IRepositoryWrapper repoWrapper, IMapper mapper) : base(repoWrapper, mapper)  { }
        [HttpGet]
        public ActionResult<LitePaymentMethodDTO> Get()
        {   
            return Ok(mapper.Map<IEnumerable<LitePaymentMethodDTO>>(repoWrapper.PaymentMethod.Get()).ToList());
        }
        
        [HttpPost]
        public ActionResult<PaymentMethodDTO> Post([FromBody] LiteCorporateDTO value)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (value == null) return BadRequest();
            try
            {
                repoWrapper.PaymentMethod.Insert(mapper.Map<PaymentMethod>(value));
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
            var entity = repoWrapper.PaymentMethod.GetById(id);
            if (entity == null) return BadRequest("Value with the given id is null");
            repoWrapper.PaymentMethod.Delete(entity);
            repoWrapper.Save();
            return Ok();
        }
    }
}