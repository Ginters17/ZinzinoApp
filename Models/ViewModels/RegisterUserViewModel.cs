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
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$",
        ErrorMessage = "Must contain uppercase letter, lowercase letter, number and special character.")]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long.")]
        public string Password { get; set; } // Not good to use RegEx, better to use https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$",
        ErrorMessage = "Must contain uppercase letter, lowercase letter, number and special character.")]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }
}
