using System.ComponentModel.DataAnnotations;

namespace IMSApi.EntityModel.DTO.Accounts
{
    public class AuthenticateRequest
    {
        [Required]
        
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}