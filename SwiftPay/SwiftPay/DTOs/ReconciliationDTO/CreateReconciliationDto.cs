using SwiftPay.Constants.Enums;

namespace SwiftPay.DTOs.ReconciliationDTO
{
	public class CreateReconciliationDto
	{
		public ReferenceType ReferenceType { get; set; }
		public string ReferenceID { get; set; }
		public decimal ExpectedAmount { get; set; }
		public decimal ActualAmount { get; set; }
		public string Notes { get; set; }
	}
}