using System;

namespace IMSApi.EntityModel.DTO.Accounts
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string phone { get; set; }
        public string profile_pic_url { get; set; }
        public bool IsVerified { get; set; }
        public string Password { get; set; }

    }
}