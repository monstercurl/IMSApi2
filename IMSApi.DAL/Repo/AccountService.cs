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
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

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
        

        public AuthenticateResponse Authenticate(AuthenticateRequest authDto)
        {
            var _users = _context.Account.ToList();
            var user = _users.SingleOrDefault(x => x.UserName == authDto.UserName && BC.Verify(authDto.Password,x.PasswordInHash) );
            if (user == null) return null;
         
            using (_context)
            {
                var accounts = _context.Account
                    .Include(acc => acc.Role)
                    .ToList();
            }
            var token = new JwtService(_config).GenerateSecurityToken(user);
            return new AuthenticateResponse(user, token);

        }


        public AccountResponse GetById(int id)
        {
            var user = _context.Account.SingleOrDefault(x => x.Id ==  id);
            return new AccountResponse(user);
        }

         string IAccountService.Register(RegisterRequest registerRequest, string origin)
        {
            if (_context.Account.Any(x => x.Email == registerRequest.Email))
            {
                return "Email is Already Registered";
            }
            if (_context.Account.Any(x => x.UserName == registerRequest.UserName))
            {
                return "User Name is Already Registered";
            }


            var account = new Account() {

                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                IsVerified = false,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Role = _context.Role.FirstOrDefault(x => x._role == UserRoles.endUser),
                EmailVerificationToken = randomTokenString(),
                PasswordInHash = BC.HashPassword(registerRequest.Password),
               RegisteredOn = DateTime.UtcNow



        };

       
            
            _context.Account.Add(account);
            _context.SaveChanges();

           
            sendVerificationEmail(account, origin);
            return "Registered Successfully";
        }

        private void sendVerificationEmail(Account account, string origin)
        {
            string email = account.Email;
            _emailService.Send(
               to: email,
               subject: "Email Verificartion For The API ",
               html: $@"<h3>Please Enter Below Code to verify the email</h3><h2> {account.EmailVerificationToken}</2>"
           );
        }

       public  string VerifyEmail(string Email,string token)
        {
            var account = _context.Account.SingleOrDefault(x => x.Email== Email);
            

            if (account == null || account.EmailVerificationToken != token) return "Email Verification Failed" ;

            account.IsVerified = true;
            account.VerifiedOn = DateTime.UtcNow;
            account.EmailVerificationToken = null;

            _context.Account.Update(account);
            _context.SaveChanges();
            _emailService.Send(
               to: Email,
               subject: "Email Verification Successful",
               html: $@"Email is successfully registered<br>Thanks !"
           ); ;
            return "Email Verification Successful";
        }
        private string randomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}
