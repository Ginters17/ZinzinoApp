using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.ViewModels
{
    public class RegisterUserViewModel
    {

        [Required]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }
}
