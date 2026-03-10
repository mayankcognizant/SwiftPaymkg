using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using SwiftPay.Domain.Remittance.Enums;

namespace SwiftPay.Domain.Remittance.Entities
{
	public class RemittanceRequest
	{
		[Key]
		[MaxLength(64)]
		public string RemitId { get; set; } = default!;

		// Foreign references (by ID only for Phase-1)
		[Required, MaxLength(64)]
		public string CustomerId { get; set; } = default!;

		[Required, MaxLength(64)]
		public string BeneficiaryId { get; set; } = default!;

		// Currencies (ISO 4217)
		[Required, MaxLength(3)]
		public string FromCurrency { get; set; } = default!;

		[Required, MaxLength(3)]
		public string ToCurrency { get; set; } = default!;

		// Amounts
		[Column(TypeName = "decimal(18,2)")]
		[Range(0.01, 999999999999.99)]
		public decimal SendAmount { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? ReceiverAmount { get; set; }

		// FX & Fees linkage
		[MaxLength(64)]
		public string? QuoteId { get; set; }

		[MaxLength(64)]
		public string? RateLockId { get; set; }

		[Column(TypeName = "decimal(18,6)")]
		public decimal? RateApplied { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? FeeApplied { get; set; }

		// Purpose & SoF
		[MaxLength(32)]
		public string? PurposeCode { get; set; }

		[MaxLength(64)]
		public string? SourceOfFunds { get; set; }

		// Status & lifecycle
		[Required]
		//public RemittanceStatus Status { get; set; } = RemittanceStatus.Draft;

		[Required]
		public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

		public DateTimeOffset? UpdatedDate { get; set; }

		// Audit
		[MaxLength(64)]
		public string? CreatedByUserId { get; set; }

		[MaxLength(64)]
		public string? UpdatedByUserId { get; set; }

		// Optimistic concurrency
		[Timestamp]
		public byte[] RowVersion { get; set; } = Array.Empty<byte>();
	}
}