using System;
using System.Text.Json.Serialization;

namespace IMSApi.EntityModel.DTO.Accounts
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string phone { get; set; }
        public string profile_pic_url { get; set; }
        public bool IsVerified { get; set; }
        public string JwtToken { get; set; }
        public AuthenticateResponse(AccountResponse user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            JwtToken = token;
        }

    }
}