using System;
using SwiftPay.Constants.Enums;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    // DTO for beneficiary response data
    public class BeneficiaryResponseDto
    {
        public int BeneficiaryID { get; set; }

        public int CustomerID { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public PayoutMode PayoutMode { get; set; }

        public string BankName { get; set; }

        public string BankCountry { get; set; }

        public string AccountOrWalletNo { get; set; }

        public string IFSC_IBAN_SWIFT { get; set; }

        public BeneficiaryVerificationStatus VerificationStatus { get; set; }

        public DateTime AddedDate { get; set; }

        public BeneficiaryStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
