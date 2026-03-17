using System;
using System.ComponentModel.DataAnnotations;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    // DTO for updating customer information (nullable fields allow partial updates)
    public class UpdateCustomerDto
    {
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [StringLength(1000)]
        public string? AddressJSON { get; set; }

        [StringLength(100)]
        public string? Nationality { get; set; }
    }
}
