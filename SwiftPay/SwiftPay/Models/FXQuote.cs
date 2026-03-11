using System;

namespace SwiftPay.FXModule.Api.Models
{
    public class FXQuote
    {
        public string QuoteID { get; set; } // primary key
        public string FromCurrency { get; set; } 
        public string ToCurrency { get; set; }
        public decimal MidRate { get; set; } 
        public int MarginBps { get; set; } 
        public decimal OfferedRate { get; set; } 
        public DateTime QuoteTime { get; set; }
        public DateTime ValidUntil { get; set; } 
        public string Status { get; set; } 

        // Audit & Soft Delete Fields
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}