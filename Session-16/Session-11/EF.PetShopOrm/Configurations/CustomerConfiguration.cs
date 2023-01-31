using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session_11.EF.PetShopModel;
using System.CodeDom;

namespace Session_11.EF.PetShopOrm.Configurations {
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            builder.ToTable("Customers");

            builder.HasKey(customer => customer.CustomerID);

            builder.Property(customer => customer.CustomerID).ValueGeneratedOnAdd();
            builder.Property(customer => customer.Name).HasMaxLength(50);
            builder.Property(customer => customer.Surname).HasMaxLength(50);
            builder.Property(customer => customer.Phone).HasMaxLength(15);
            builder.Property(customer => customer.TIN).HasMaxLength(15);

            builder.HasOne(customer => customer.PetShop)
                 .WithMany(petShop => petShop.Customers)
                 .HasForeignKey(customer => customer.PetShopID);
        }
    }
}
