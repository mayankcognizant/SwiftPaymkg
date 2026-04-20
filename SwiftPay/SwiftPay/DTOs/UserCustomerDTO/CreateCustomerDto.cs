using System;
using System.ComponentModel.DataAnnotations;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    // DTO containing only required fields for creating a customer profile
    public class CreateCustomerDto
    {
        // UserID is nullable in the create DTO. Regular customers are not expected
        // to supply it; Admin/Ops may provide it when creating profiles for others.
        public int? UserID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [StringLength(1000, ErrorMessage = "Address cannot exceed 1000 characters.")]
        public string AddressJSON { get; set; }

        [StringLength(100, ErrorMessage = "Nationality cannot exceed 100 characters.")]
        public string Nationality { get; set; }
    }
}
