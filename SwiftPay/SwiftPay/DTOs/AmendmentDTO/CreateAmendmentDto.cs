using System.ComponentModel.DataAnnotations;

namespace SwiftPay.DTOs.AmendmentDTO
{
    public class CreateAmendmentDto
    {
        [Required]
        public int RemitId { get; set; }

        [Required]
        [StringLength(100)]
        public string FieldChanged { get; set; }

        public string? OldValue { get; set; }

        [Required]
        public string NewValue { get; set; }

        [Required]
        public int RequestedBy { get; set; }
    }
}