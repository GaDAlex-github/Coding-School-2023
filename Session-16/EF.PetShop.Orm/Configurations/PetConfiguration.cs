using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Session_11.EF.PetShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopOrm.Configurations {
    public class PetConfiguration : IEntityTypeConfiguration<Pet> {
        public void Configure(EntityTypeBuilder<Pet> builder) {
            builder.ToTable("Pets");

            builder.HasKey(pet => pet.PetID);

            builder.Property(pet => pet.PetID).ValueGeneratedOnAdd();
            builder.Property(pet => pet.Breed).HasMaxLength(20);
            builder.Property(pet => pet.AnimalType).HasMaxLength(20);
            builder.Property(pet => pet.Status).HasMaxLength(15);
            builder.Property(pet => pet.Price);
            builder.Property(pet => pet.Cost);

            builder.HasOne(pet => pet.PetShop)
                 .WithMany(petShop => petShop.Pets)
                 .HasForeignKey(pet => pet.PetShopID);
        }
    }
}
