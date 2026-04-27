using SwiftPay.Constants.Enums;

namespace SwiftPay.DTOs.SettlementDTO
{
    public class UpdateBatchStatusDto
    {
        public int BatchID { get; set; }
        public Status Status { get; set; }
    }
}