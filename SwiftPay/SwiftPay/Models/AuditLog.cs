using System;

namespace SwiftPay.Domain.Remittance.Entities
{
    /// <summary>
    /// Minimal audit log entity for tracking "Who did what" events.
    /// Does not store sensitive data values or complex JSON.
    /// </summary>
    public class AuditLog
    {
        /// <summary>Primary key for audit record</summary>
        public int AuditID { get; set; }

        /// <summary>User ID of the actor. Nullable to allow self-registration events.</summary>
        public int? UserID { get; set; }

        /// <summary>The action performed (e.g., "Create", "Update", "Delete")</summary>
        public string Action { get; set; }

        /// <summary>The name of the table/entity being modified</summary>
        public string Resource { get; set; }

        /// <summary>Timestamp of when the action occurred</summary>
        public DateTime Timestamp { get; set; }

        /// <summary>Soft delete flag - when true, record is logically deleted but preserved in database</summary>
        public bool IsDeleted { get; set; } = false;
    }
}