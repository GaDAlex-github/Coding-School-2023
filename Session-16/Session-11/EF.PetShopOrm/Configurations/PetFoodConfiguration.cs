using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Session_11.EF.PetShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopOrm.Configurations {
    public class PetFoodConfiguration : IEntityTypeConfiguration<PetFood> {
        public void Configure(EntityTypeBuilder<PetFood> builder) {
            builder.ToTable("PetFoods");

            builder.HasKey(pet => pet.PetFoodID);

            builder.Property(pet => pet.PetFoodID).ValueGeneratedOnAdd();
            builder.Property(pet => pet.AnimalType).HasMaxLength(20);
            builder.Property(pet => pet.Price);
            builder.Property(pet => pet.Cost);

            builder.HasOne(pet => pet.PetShop)
                 .WithMany(petShop => petShop.PetFoods)
                 .HasForeignKey(pet => pet.PetShopID);
        }
    }
}
