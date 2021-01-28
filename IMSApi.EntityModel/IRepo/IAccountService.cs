using IMSApi.EntityModel.DTO.Accounts;
using IMSApi.EntityModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSApi.EntityModel.IRepo
{
    public interface IAccountService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest authDto);
        public AccountResponse GetById(int id);
       
        public string Register(RegisterRequest registerRequest,string origin);
        string VerifyEmail(string email,string token);
    }
}
