using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
    }
}