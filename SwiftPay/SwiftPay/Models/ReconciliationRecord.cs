using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class ReconciliationRecord
    {
        [Key]
        public int ReconID { get; set; }

        [Required]
        [StringLength(50)]
        public string? ReferenceType { get; set; } // Remit, Instruction, PartnerAck

        [Required]
        [StringLength(100)]
        public string? ReferenceID { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "9999999999999.9999")]
        public decimal ExpectedAmount { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "9999999999999.9999")]
        public decimal ActualAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string? Result { get; set; } // Matched, Mismatched

        [Required]
        public DateTime ReconDate { get; set; } = DateTime.Now;

        public string? Notes { get; set; } // Optional
    }
}
