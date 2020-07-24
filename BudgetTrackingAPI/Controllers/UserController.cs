using AutoMapper;
using BudgetTracking.DTOs;
using BudgetTracking.Errors;
using BudgetTracking.Models;
using BudgetTracking.Models.IncomingModels;
using BudgetTracking.Repositories.Wrappers;
using BudgetTrackingAPI.Utils.Hashing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IRepositoryWrapper repoWrapper, IMapper mapper) : base(repoWrapper, mapper) { }
        [HttpGet]
        [Route("Me")]
        public ActionResult<LiteUserDTO> Me()
        {
            return mapper.Map<LiteUserDTO>(BudgetTrackingUserResult);
        }
        [HttpPost]
        [Route("Signup")]
        public ActionResult<UserDTO> SignUp([FromBody]SignUpModel signupModel)
        {
            LiteUserDTO user;
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (signupModel == null) return BadRequest();
            if (repoWrapper.User.GetByCondition(x => x.MailAddress == signupModel.Email).Count() != 0)
                return BadRequest(BudgetTrackingErrors.AuthErrors.MailAlreadyRegistered);
            var salt = Salt.Create();
            var hash = Hash.Create(signupModel.Password, salt);
            try
            {
                user = new LiteUserDTO()
                {
                    Salt = salt,
                    HashedPassword = hash,
                    Name = signupModel.Name,
                    MailAddress = signupModel.Email
                };
                var a = repoWrapper.User.Insert(mapper.Map<User>(user));
            }
            catch
            {
                return BadRequest();
            }
            return Ok(user);
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult<UserDTO> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (loginModel == null) return BadRequest();
            User user = repoWrapper.User.GetByCondition(x => x.MailAddress == loginModel.Email).FirstOrDefault();
            if (user == null) return BadRequest(BudgetTrackingErrors.AuthErrors.MailAddressNotFound);
            if (Hash.Validate(loginModel.Password, user.Salt, user.HashedPassword))
            {
                return Ok(mapper.Map<UserDTO>(user));
            }
            else
            {
                return BadRequest(BudgetTrackingErrors.AuthErrors.WrongPassword);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            repoWrapper.User.Delete(BudgetTrackingUserResult);
            repoWrapper.Save();
            return Ok();
        }
    }
}
