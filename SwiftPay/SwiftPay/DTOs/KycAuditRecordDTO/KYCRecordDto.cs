using System;
using System.ComponentModel.DataAnnotations;
using SwiftPay.Constants.Enums;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    public class CreateKYCRecordDto
    {
        // Allow omitting UserID for regular users; controller will assign from JWT claims.
        public int? UserID { get; set; }

        [Required(ErrorMessage = "KYC Level is required.")]
        public KYCLevel KYCLevel { get; set; }
    }

    public class UpdateKYCRecordDto
    {
        public KYCLevel? KYCLevel { get; set; }

        [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters.")]
        public string? Notes { get; set; }
    }

    public class KYCRecordResponseDto
    {
        public int KYCID { get; set; }

        public int UserID { get; set; }

        public KYCLevel KYCLevel { get; set; }

        public KycVerificationStatus VerificationStatus { get; set; }

        public DateTime? VerifiedDate { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
