using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Session_11.EF.PetShopModel;

namespace Session_11.EF.PetShopOrm.Configurations {
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            builder.ToTable("Customers");
            
            builder.HasKey(customer => customer.ID);

            builder.Property(customer => customer.ID).ValueGeneratedOnAdd();
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
