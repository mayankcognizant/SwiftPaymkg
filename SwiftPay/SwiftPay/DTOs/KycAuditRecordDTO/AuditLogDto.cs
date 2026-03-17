using System;
using System.ComponentModel.DataAnnotations;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    public class AuditLogResponseDto
    {
        public int AuditID { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Action { get; set; }

        public string Resource { get; set; }

        public DateTime Timestamp { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
