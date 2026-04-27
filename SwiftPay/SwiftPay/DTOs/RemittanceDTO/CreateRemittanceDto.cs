using System.ComponentModel.DataAnnotations;

namespace SwiftPay.DTOs.RemittanceDTO
{
<<<<<<< Updated upstream
	public class CreateRemittanceDto
	{
		// --- 1. THE WHO ---
=======
	// DTO containing only required fields for creating a remittance request
	public class CreateRemittanceDto
	{
>>>>>>> Stashed changes
		[Required]
		public int CustomerId { get; set; }

		[Required]
		public int BeneficiaryId { get; set; }

<<<<<<< Updated upstream

		// --- 2. THE MONEY & RATE ---
		[Required]
		[Range(1, 1000000)]
		public decimal SendAmount { get; set; }

		[Required]
		public string? QuoteId { get; set; }


		// --- 3. THE COMPLIANCE ---
		[Required]
		[MaxLength(100)]
		public string PurposeCode { get; set; }

		[Required]
		[MaxLength(100)]
		public string SourceOfFunds { get; set; }


		// --- 4. CURRENCIES ---
		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string FromCurrency { get; set; } // e.g., "USD"

		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string ToCurrency { get; set; } // e.g., "EUR"
=======
		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string FromCurrency { get; set; }

		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string ToCurrency { get; set; }

		[Required]
		[Range(0.01, double.MaxValue)]
		public decimal SendAmount { get; set; }
>>>>>>> Stashed changes
	}
}