using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftPay.Constants.Enums;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Config.Configuration
{
    public class BeneficiaryConfiguration : IEntityTypeConfiguration<Beneficiary>
    {
        public void Configure(EntityTypeBuilder<Beneficiary> builder)
        {
            builder.HasKey(b => b.BeneficiaryID);
            builder.Property(b => b.BeneficiaryID).ValueGeneratedOnAdd();

            builder.Property(b => b.CustomerID).IsRequired();

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.PayoutMode)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.BankName)
                .HasMaxLength(255);

            builder.Property(b => b.BankCountry)
                .HasMaxLength(100);

            builder.Property(b => b.AccountOrWalletNo)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(b => b.AccountOrWalletNo)
                .IsUnique();

            builder.Property(b => b.IFSC_IBAN_SWIFT)
                .HasMaxLength(50);

            builder.Property(b => b.VerificationStatus)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue(BeneficiaryVerificationStatus.Pending);

            builder.Property(b => b.AddedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(b => b.Status)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue(BeneficiaryStatus.Active);

            // CreatedAt with default current timestamp
            builder.Property(b => b.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // UpdatedAt with default current timestamp
            builder.Property(b => b.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // IsDeleted with default value false
            builder.Property(b => b.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Restrict cascade delete to prevent accidental data loss
            builder.HasOne(b => b.Customer)
                .WithMany()
                .HasForeignKey(b => b.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
