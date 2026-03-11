using System;

namespace SwiftPay.FXModule.Api.Models
{
    public class FeeRule
    {
        public string FeeRuleID { get; set; }
        public string Corridor { get; set; } 
        public string PayoutMode { get; set; } 
        public string FeeType { get; set; } 
        public decimal FeeValue { get; set; } 
        public decimal MinFee { get; set; } 
        public decimal MaxFee { get; set; } 
        public DateTime EffectiveFrom { get; set; } 
        public DateTime EffectiveTo { get; set; } 
        public string Status { get; set; } 

        // Audit & Soft Delete Fields
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}