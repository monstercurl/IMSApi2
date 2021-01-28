using System;
using System.Collections.Generic;

namespace IMSApi.EntityModel.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordInHash { get; set; }
        public string profile_pic_url { get; set; }

        public Role Role { get; set; }
        public string EmailVerificationToken { get; set; }
        public string PasswordResetToken { get; set; }
        public DateTime PasswordResetTokenExpiry { get; set; }

        public DateTime VerifiedOn { get; set; }

        public bool IsVerified { get; set; }
        public bool IsDeactivated { get; set; }

        public DateTime RegisteredOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        
    }
}