using System.ComponentModel.DataAnnotations;
using SwiftPay.Constants.Enums;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    // DTO for updating beneficiary information (nullable fields allow partial updates)
    public class UpdateBeneficiaryDto
    {
        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }

        public PayoutMode? PayoutMode { get; set; }

        [StringLength(255)]
        public string? BankName { get; set; }

        [StringLength(100)]
        public string? BankCountry { get; set; }

        [StringLength(100)]
        public string? AccountOrWalletNo { get; set; }

        [StringLength(50)]
        public string? IFSC_IBAN_SWIFT { get; set; }
    }
}
