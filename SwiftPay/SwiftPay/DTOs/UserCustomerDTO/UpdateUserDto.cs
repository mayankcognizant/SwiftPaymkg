using System.ComponentModel.DataAnnotations;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    // DTO for updating user information (nullable fields allow partial updates)
    public class UpdateUserDto
    {
        [StringLength(255)]
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }
    }
}
