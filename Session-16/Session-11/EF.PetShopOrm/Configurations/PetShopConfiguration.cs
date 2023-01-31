using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session_11.EF.PetShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopOrm.Configurations {
    public class PetShopConfiguration : IEntityTypeConfiguration<PetShop> {
        public void Configure(EntityTypeBuilder<PetShop> builder) {
            builder.ToTable("PetShop");

            builder.HasKey(petShop => petShop.PetShopID);

            builder.Property(petShop => petShop.PetShopID).ValueGeneratedOnAdd();
           
        }
    }
}
