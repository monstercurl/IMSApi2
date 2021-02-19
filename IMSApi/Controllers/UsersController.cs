using IMSApi.EntityModel.DTO.Accounts;
using IMSApi.EntityModel.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Accounts;

namespace IMSApi.Controllers
{   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IAccountService _accountService;

        public UsersController(IAccountService accountService)
            {
            _accountService = accountService;

            }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest authenticateRequest) 
        {
            var response = _accountService.Authenticate(authenticateRequest);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {

            return Ok(new { message = _accountService.Register(model, Request.Headers["origin"]) });

        }

        [AllowAnonymous]
        [HttpPost("verifyemail")]
        public IActionResult VerifyEmail(VerifyEmailRequest model)
        {
           
            return Ok(new { message =  _accountService.VerifyEmail(model.Email,model.Token) });
        }


        [Authorize(Roles = UserRoles.endUser)]
        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            var users = _accountService.GetById(Id);
            return Ok(users);
        }

        
    }
}
