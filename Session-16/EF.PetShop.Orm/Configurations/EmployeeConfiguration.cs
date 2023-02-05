using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Session_11.EF.PetShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopOrm.Configurations {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee> {
        public void Configure(EntityTypeBuilder<Employee> builder) {
            builder.ToTable("Employees");

            builder.HasKey(employee => employee.ID);

            builder.Property(employee => employee.ID).ValueGeneratedOnAdd();
            builder.Property(employee => employee.Name).HasMaxLength(50);
            builder.Property(employee => employee.Surname).HasMaxLength(50);
            builder.Property(employee => employee.EmployeeType).HasMaxLength(15);
            builder.Property(employee => employee.SalaryPerMonth).HasMaxLength(15);

            builder.HasOne(employee => employee.PetShop)
                 .WithMany(petShop => petShop.Employees)
                 .HasForeignKey(employee => employee.PetShopID);
            //builder.HasOne(employee => employee.Transactions)
            //    .WithMany(transaction => transaction.)
            //    .HasForeignKey(transaction => transaction.EmployeeID);
        }
    }
}