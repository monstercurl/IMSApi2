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

            _accountService.Register(model, Request.Headers["origin"]);
            return Ok(new { message = "Registration successful, please check your email for verification instructions" });
        }
        [AllowAnonymous]
        [HttpPost("verify-email")]
        public IActionResult VerifyEmail(VerifyEmailRequest model)
        {
            _accountService.VerifyEmail(model.Token);
            return Ok(new { message = "Verification successful, you can now login" });
        }


        [Authorize(Roles = "end")]
        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            var users = _accountService.GetById(Id);
            return Ok(users);
        }

        [Authorize(Roles = "admin")]
        [Route("/api")]
        [HttpGet]
        public IActionResult Register(int Id)
        {
            return Ok("Working For End Customer");
        }
    }
}
