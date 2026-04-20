using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Config.Configuration
{
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.HasKey(a => a.AuditID);
            builder.Property(a => a.AuditID).ValueGeneratedOnAdd();

            builder.Property(a => a.UserID)
                .IsRequired(false);  // Nullable - allows self-registration events

            builder.Property(a => a.Action)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.Resource)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.Timestamp)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // IsDeleted for soft delete with default value false
            builder.Property(a => a.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Global query filter to hide soft-deleted audit logs
            builder.HasQueryFilter(a => !a.IsDeleted);

            // Create index on UserID for faster queries
            builder.HasIndex(a => a.UserID);

            // Create index on Resource for faster queries
            builder.HasIndex(a => a.Resource);

            // Create composite index on Timestamp and UserID for date range queries
            builder.HasIndex(a => new { a.Timestamp, a.UserID });

            // Index on IsDeleted to optimize soft delete queries
            builder.HasIndex(a => a.IsDeleted);
        }
    }
}
