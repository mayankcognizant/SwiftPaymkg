using System;

namespace SwiftPay.DTOs.SettlementDTO
{
    public class GenerateBatchDto
    {
        public string Corridor { get; set; }
		public DateTimeOffset PeriodStart { get; set; }
		public DateTimeOffset PeriodEnd { get; set; }
	}
}