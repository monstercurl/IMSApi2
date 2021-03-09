using System.ComponentModel.DataAnnotations;

namespace IMSApi.EntityModel.DTO.Accounts
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }


    }
}