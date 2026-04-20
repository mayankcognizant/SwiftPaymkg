using System.ComponentModel.DataAnnotations;
using SwiftPay.Constants.Enums;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    // DTO containing only required fields for creating a beneficiary
    public class CreateBeneficiaryDto
    {
        // CustomerID is nullable so that frontend (regular users) do not need to provide it.
        // The controller will populate this from the caller's JWT.
        public int? CustomerID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Country must be between 2 and 100 characters.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "PayoutMode is required.")]
        public PayoutMode PayoutMode { get; set; }

        [StringLength(255, ErrorMessage = "BankName cannot exceed 255 characters.")]
        public string BankName { get; set; }

        [StringLength(100, ErrorMessage = "BankCountry cannot exceed 100 characters.")]
        public string BankCountry { get; set; }

        [Required(ErrorMessage = "AccountOrWalletNo is required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "AccountOrWalletNo must be between 5 and 100 characters.")]
        public string AccountOrWalletNo { get; set; }

        [StringLength(50, ErrorMessage = "IFSC/IBAN/SWIFT cannot exceed 50 characters.")]
        public string IFSC_IBAN_SWIFT { get; set; }
    }
}
