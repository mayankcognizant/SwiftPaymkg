using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftPay.FXModule.Api.Models;

namespace SwiftPay.Config.Configuration
{
    public class FXQuoteConfiguration : 
        IEntityTypeConfiguration<FXQuote>,
        IEntityTypeConfiguration<FeeRule>,
        IEntityTypeConfiguration<RateLock>
    {
        // 1. Configuration for FXQuote
        public void Configure(EntityTypeBuilder<FXQuote> builder)
        {
            builder.HasKey(f => f.QuoteID); 
            builder.Property(f => f.QuoteID).HasDefaultValueSql("NEWID()");
            
            builder.Property(f => f.FromCurrency).IsRequired().HasDefaultValue(string.Empty); 
            builder.Property(f => f.ToCurrency).IsRequired().HasDefaultValue(string.Empty); 
            builder.Property(f => f.Status).IsRequired().HasDefaultValue("Active"); 
            
            builder.Property(f => f.QuoteTime).HasDefaultValueSql("GETUTCDATE()"); 
            
            builder.Property(f => f.MidRate).HasPrecision(18, 6); 
            builder.Property(f => f.OfferedRate).HasPrecision(18, 6); 

            // Audit & Soft Delete Fields
            builder.Property(f => f.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(f => f.UpdateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(f => f.IsDeleted).HasDefaultValue(false);
        }

        // 2. Configuration for FeeRule
        public void Configure(EntityTypeBuilder<FeeRule> builder)
        {
            builder.HasKey(f => f.FeeRuleID); 
            builder.Property(f => f.FeeRuleID).HasDefaultValueSql("NEWID()");
            
            builder.Property(f => f.Corridor).IsRequired().HasDefaultValue(string.Empty); 
            builder.Property(f => f.PayoutMode).IsRequired().HasDefaultValue(string.Empty); 
            builder.Property(f => f.FeeType).IsRequired().HasDefaultValue(string.Empty); 
            builder.Property(f => f.Status).IsRequired().HasDefaultValue("Active"); 
            builder.Property(f => f.FeeValue).HasPrecision(18, 2); 
            builder.Property(f => f.MinFee).HasPrecision(18, 2); 
            builder.Property(f => f.MaxFee).HasPrecision(18, 2); 

            // Audit & Soft Delete Fields
            builder.Property(f => f.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(f => f.UpdateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(f => f.IsDeleted).HasDefaultValue(false);
        }

        // 3. Configuration for RateLock
        public void Configure(EntityTypeBuilder<RateLock> builder)
        {
            builder.HasKey(r => r.LockID); 
            builder.Property(r => r.LockID).HasDefaultValueSql("NEWID()");
            
            builder.Property(r => r.QuoteID).IsRequired().HasDefaultValue(string.Empty); 
            builder.Property(r => r.CustomerID).IsRequired().HasDefaultValue(string.Empty); 
            builder.Property(r => r.Status).IsRequired().HasDefaultValue("Locked"); 
            
            builder.Property(r => r.LockStart).HasDefaultValueSql("GETUTCDATE()"); 

            // Audit & Soft Delete Fields
            builder.Property(r => r.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(r => r.UpdateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);
        }
    }
}