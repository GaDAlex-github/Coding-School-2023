using FuelStation.Model;
using FuelStation.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configurations {
    public class ItemConfiguration : IEntityTypeConfiguration<Item> {
        public void Configure(EntityTypeBuilder<Item> builder) {
            // Table Name
            builder.ToTable("Items");

            // Primary Key
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(t => t.Code).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(200).IsRequired();
            builder.Property(t => t.ItemType).IsRequired();
            builder.Property(t => t.Price).HasPrecision(7, 2).IsRequired();
            builder.Property(t => t.Cost).HasPrecision(7, 2).IsRequired();
        }
    }
}
