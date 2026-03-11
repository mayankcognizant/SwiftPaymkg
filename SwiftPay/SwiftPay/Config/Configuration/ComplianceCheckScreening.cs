using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftPay.Domain.Remittance.Entities;
using System;

namespace SwiftPay.Config.Configuration
{
    public class ComplianceScreeningConfiguration :
        IEntityTypeConfiguration<ComplianceCheck>,
        IEntityTypeConfiguration<ComplianceDecision>,
        IEntityTypeConfiguration<RoutingRule>,
        IEntityTypeConfiguration<PayoutInstruction>
    {
        // --- 1. ComplianceCheck Configuration ---
        public void Configure(EntityTypeBuilder<ComplianceCheck> builder)
        {
            builder.ToTable("ComplianceChecks");
            builder.HasKey(c => c.CheckId);
            builder.Property(c => c.CheckId).HasMaxLength(64).HasDefaultValueSql("NEWID()");

            builder.Property(c => c.RemitId).IsRequired().HasMaxLength(64);
            builder.Property(c => c.CheckType).IsRequired().HasMaxLength(32);

            builder.Property(c => c.Result).IsRequired().HasMaxLength(20).HasDefaultValue("Pending");
            builder.Property(c => c.Severity).IsRequired().HasMaxLength(20).HasDefaultValue("Low");

            builder.Property(c => c.CheckedDate).HasDefaultValueSql("GETUTCDATE()");

            // Audit Fields
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.UpdateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);

            builder.Property(c => c.RowVersion).IsRowVersion();
        }

        // --- 2. ComplianceDecision Configuration ---
        public void Configure(EntityTypeBuilder<ComplianceDecision> builder)
        {
            builder.ToTable("ComplianceDecisions");
            builder.HasKey(d => d.DecisionId);
            builder.Property(d => d.DecisionId).HasMaxLength(64).HasDefaultValueSql("NEWID()");

            builder.Property(d => d.RemitId).IsRequired().HasMaxLength(64);
            builder.Property(d => d.AnalystId).IsRequired().HasMaxLength(64);
            builder.Property(d => d.Decision).IsRequired().HasMaxLength(20);
            builder.Property(d => d.Notes).HasMaxLength(1000);

            builder.Property(d => d.DecisionDate).HasDefaultValueSql("GETUTCDATE()");

            // Audit Fields
            builder.Property(d => d.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(d => d.UpdateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(d => d.IsDeleted).HasDefaultValue(false);

            builder.Property(d => d.RowVersion).IsRowVersion();
        }

        // --- 3. RoutingRule Configuration ---
        public void Configure(EntityTypeBuilder<RoutingRule> builder)
        {
            builder.ToTable("RoutingRules");
            builder.HasKey(r => r.RuleId);
            builder.Property(r => r.RuleId).HasMaxLength(64).HasDefaultValueSql("NEWID()");

            builder.Property(r => r.Corridor).IsRequired().HasMaxLength(16).IsUnicode(false);
            builder.Property(r => r.PayoutMode).IsRequired().HasMaxLength(32);
            builder.Property(r => r.PartnerCode).IsRequired().HasMaxLength(64);

            builder.Property(r => r.Priority).IsRequired().HasDefaultValue(1);
            builder.Property(r => r.Status).IsRequired().HasMaxLength(20).HasDefaultValue("Active");

            // Audit Fields
            builder.Property(r => r.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(r => r.UpdateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);

            builder.Property(r => r.RowVersion).IsRowVersion();
        }

        // --- 4. PayoutInstruction Configuration ---
        public void Configure(EntityTypeBuilder<PayoutInstruction> builder)
        {
            builder.ToTable("PayoutInstructions");
            builder.HasKey(p => p.InstructionId);
            builder.Property(p => p.InstructionId).HasMaxLength(64).HasDefaultValueSql("NEWID()");

            builder.Property(p => p.RemitId).IsRequired().HasMaxLength(64);
            builder.Property(p => p.PartnerCode).IsRequired().HasMaxLength(64);
            builder.Property(p => p.PayloadJson).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(p => p.AckRef).HasMaxLength(128);

            builder.Property(p => p.PartnerStatus).IsRequired().HasMaxLength(32).HasDefaultValue("Sent");
            builder.Property(p => p.SentDate).HasDefaultValueSql("GETUTCDATE()");

            // Audit Fields
            builder.Property(p => p.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.UpdateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            builder.Property(p => p.RowVersion).IsRowVersion();
        }
    }
}