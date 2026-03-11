using System;

namespace SwiftPay.FXModule.Api.Models
{
    public class RateLock
    {
        public string LockID { get; set; } 
        public string QuoteID { get; set; } 
        public string CustomerID { get; set; } 
        public DateTime LockStart { get; set; } 
        public DateTime LockExpiry { get; set; } 
        public string Status { get; set; } 

        // Audit & Soft Delete Fields
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}