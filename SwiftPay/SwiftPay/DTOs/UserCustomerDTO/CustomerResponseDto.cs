using System;
using SwiftPay.Constants.Enums;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    // DTO for customer response data
    public class CustomerResponseDto
    {
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public DateTime? DOB { get; set; }

        public string AddressJSON { get; set; }

        public string Nationality { get; set; }

        public CustomerRiskRating RiskRating { get; set; }

        public CustomerStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
