using System.ComponentModel.DataAnnotations;

namespace SwiftPay.DTOs.ComplianceDTO
{
    // DTO containing only required fields for creating a compliance check
    public class CreateComplianceCheckDto
    {
        [Required]
        public int RemitId { get; set; }

        [Required]
        [StringLength(50)]
        public string CheckType { get; set; } // e.g., Sanctions, PEP, AML, Geo

        [Required]
        [StringLength(20)]
        public string Result { get; set; } // e.g., Clear, Flag, Hold

        [Required]
        [StringLength(20)]
        public string Severity { get; set; } // e.g., Low, Medium, High

        public string? Remarks { get; set; }
    }
}