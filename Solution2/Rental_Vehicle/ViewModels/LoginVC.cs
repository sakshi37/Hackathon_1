using System.ComponentModel.DataAnnotations;
namespace Rental_Vehicle.ViewModels
{
    public class LoginVC
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
