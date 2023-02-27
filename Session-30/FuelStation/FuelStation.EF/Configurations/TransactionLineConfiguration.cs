﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FuelStation.Model;

namespace FuelStation.EF.Configurations {
    public class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine> {
        public void Configure(EntityTypeBuilder<TransactionLine> builder) {
            // Table Name
            builder.ToTable("TransactionLines");

            // Primary Key
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.ItemPrice).HasPrecision(7, 2).IsRequired();
            builder.Property(t => t.NetValue).HasPrecision(7, 2).IsRequired();
            builder.Property(t => t.DiscountPercent).IsRequired();
            builder.Property(t => t.DiscountValue).HasPrecision(7, 2).IsRequired();
            builder.Property(t => t.TotalValue).HasPrecision(9, 2).IsRequired();

            // Relations
            builder.HasOne(t => t.Transaction)
                .WithMany(t => t.TransactionLines)
                .HasForeignKey(t => t.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Item)
                .WithMany(t => t.TransactionLines)
                .HasForeignKey(t => t.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}