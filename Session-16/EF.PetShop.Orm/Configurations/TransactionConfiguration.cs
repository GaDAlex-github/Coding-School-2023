using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Session_11.EF.PetShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopOrm.Configurations {
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction> {
        public void Configure(EntityTypeBuilder<Transaction> builder) {
            builder.ToTable("Transactions");

            builder.HasKey(transaction => transaction.TransactionID);

            builder.Property(transaction => transaction.TransactionID).ValueGeneratedOnAdd();
            builder.Property(transaction => transaction.TransactionDate).IsRequired(true);
            builder.Property(transaction => transaction.CustomerID);
            builder.Property(transaction => transaction.EmployeeID);
            builder.Property(transaction => transaction.PetID);
            builder.Property(transaction => transaction.PetPrice);
            builder.Property(transaction => transaction.PetFoodID);
            builder.Property(transaction => transaction.PetFoodQty);
            builder.Property(transaction => transaction.PetFoodPrice);
            builder.Property(transaction => transaction.TotalPrice);

            builder.HasOne(transaction => transaction.PetShop)
        .WithMany(petShop => petShop.Transactions)
        .HasForeignKey(transaction => transaction.PetShopID);
        }
    }
}
