using IMSApi.DAL.Common;
using IMSApi.EntityModel.DTO.Accounts;
using IMSApi.EntityModel.Entities;
using IMSApi.EntityModel.IRepo;
using Microsoft.Extensions.Configuration;
using System;
using BC = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace IMSApi.DAL.Repo
{
    public class AccountService : IAccountService
      
    {
        private IConfiguration _config;
        private readonly IMSApiDbContext _context;
        
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        public AccountService(IConfiguration config, IMSApiDbContext context,
             IOptions<AppSettings> appSettings, IEmailService emailService) 
        {
            _config = config;
            
            _context = context;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }
        private List<AccountResponse> _users = new List<AccountResponse>
        {
            new AccountResponse { Id = 1,Role = "end", FirstName = "Test", LastName = "User", UserName = "test", Password = "test" },
            new AccountResponse { Id = 2,Role = "admin", FirstName = "Test2", LastName = "User", UserName = "test1", Password = "test" }
        }; 
        public AuthenticateResponse Authenticate(AuthenticateRequest authDto)
        {
            var user = _users.SingleOrDefault(x => x.UserName == authDto.UserName && x.Password == authDto.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = new JwtService(_config).GenerateSecurityToken(user);

            return new AuthenticateResponse(user, token);

        }

        public IEnumerable<AccountResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public AccountResponse GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

         string IAccountService.Register(RegisterRequest registerRequest, string origin)
        {
            if (_context.Account.Any(x => x.Email == registerRequest.Email))
            {
                return "Email is Already Registered";
                // send already registered error in email to prevent account enumeration
                //sendAlreadyRegisteredEmail(model.Email, origin);
               // return;
            }

            // map model to new account object
            var account = new Account() {
                Id = 10,
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                IsVerified = false,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest .LastName,
                //Role = new Role() {Id = 1,_role = UserRoles.endUser_customer}
            };

            
            //account.Role = new Role() {Id = 1,_role=Roles. };
            account.RegisteredOn = DateTime.UtcNow;
           // account.VerificationToken = randomTokenString();

            // hash password
            account.PasswordInHash = BC.HashPassword(registerRequest.Password);

            // save account
            _context.Account.Add(account);
            _context.SaveChanges();

            // send email
            sendVerificationEmail(account, origin);
            return "Registered Successfully";
        }

        private void sendVerificationEmail(object account, string origin)
        {
            throw new NotImplementedException();
        }

        void IAccountService.VerifyEmail(string token)
        {
            throw new NotImplementedException();
        }
    }
}
