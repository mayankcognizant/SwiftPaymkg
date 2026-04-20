using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftPay.Constants.Enums;
using SwiftPay.Domain.Remittance.Entities;
using SwiftPay.Models;

namespace SwiftPay.Config.Configuration
{
    public class CustomerProfileConfiguration : IEntityTypeConfiguration<CustomerProfile>
    {
        public void Configure(EntityTypeBuilder<CustomerProfile> builder)
        {
            builder.HasKey(c => c.CustomerID);
            builder.Property(c => c.CustomerID).ValueGeneratedOnAdd();

                 builder.Property(c => c.UserID).IsRequired();
                 // Unique UserID, but ignore soft-deleted profiles
                 builder.HasIndex(c => c.UserID)
                     .HasFilter("[IsDeleted] = 0")
                     .IsUnique();

            builder.Property(c => c.DOB).HasColumnType("date");
            builder.Property(c => c.AddressJSON).HasColumnType("text");
            builder.Property(c => c.Nationality).HasMaxLength(100);

            // store enum as string so it maps to VARCHAR(50)
            builder.Property(c => c.RiskRating)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue(CustomerRiskRating.Low);

            builder.Property(c => c.Status)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue(CustomerStatus.Active);

            // CreatedAt with default current timestamp
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // UpdatedAt with default current timestamp
            builder.Property(c => c.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // IsDeleted with default value false
            builder.Property(c => c.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Global query filter to hide soft-deleted customer profiles
            builder.HasQueryFilter(c => !c.IsDeleted);

            builder.HasOne(c => c.User)
                   .WithMany()
                   .HasForeignKey(c => c.UserID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
