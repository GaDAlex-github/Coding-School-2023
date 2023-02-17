using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configurations {
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction> {
        public void Configure(EntityTypeBuilder<Transaction> builder) {
            // Table Name
            builder.ToTable("Transactions");

            // Primary Key
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(t => t.Date).IsRequired();
            builder.Property(t => t.PaymentMethod).IsRequired();
            builder.Property(t => t.TotalValue).HasPrecision(9, 2).IsRequired();

            // Relations
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Employee)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
