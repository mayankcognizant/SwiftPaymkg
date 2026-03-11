using System;

namespace SwiftPay.Domain.Remittance.Entities
{
    public class RoutingRule
    {
        public string RuleId { get; set; }
        public string Corridor { get; set; } // e.g., GBP-INR, USD-PHP
        public string PayoutMode { get; set; } // e.g., CashPickup, BankAccount, Wallet
        public string PartnerCode { get; set; } // e.g., WESTERN_UNION, MUTHOOT
        public int Priority { get; set; } // Numerical order for routing
        public string Status { get; set; } // Active, Inactive, Suspended
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; } // For concurrency handling
    }
}