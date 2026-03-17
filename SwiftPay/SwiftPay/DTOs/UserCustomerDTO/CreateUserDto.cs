using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    // DTO containing only required fields for creating a user
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be a valid email address.")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [Phone(ErrorMessage = "Phone must be a valid phone number.")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "Phone must be between 7 and 20 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(512, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 512 characters.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
