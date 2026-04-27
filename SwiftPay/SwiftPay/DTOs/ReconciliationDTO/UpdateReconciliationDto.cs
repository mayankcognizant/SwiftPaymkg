using SwiftPay.Constants.Enums;

namespace SwiftPay.DTOs.ReconciliationDTO
{
    public class UpdateReconciliationDto
    {
        public int ReconID { get; set; }
        public Result Result { get; set; }
        public string Notes { get; set; }
    }
}