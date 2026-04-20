using System;

namespace SwiftPay.Models
{
    /// <summary>
    /// Base entity for common audit fields.
    /// All entities inheriting from this will automatically track creation and update timestamps.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>When the record was created</summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>When the record was last updated</summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>Soft delete flag</summary>
        public bool IsDeleted { get; set; } = false;
    }
}
