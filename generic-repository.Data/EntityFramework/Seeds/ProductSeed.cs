using generic_repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Data.EntityFramework.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "MSI RTX 2060 6GB 192bit Ekran Kartı",
                    Quantity = 2,
                    Price = 4500m,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "AMD Ryzen5 3600X 3.8Mhz İşlemci",
                    Quantity = 2,
                    Price = 2250m,
                    IsDeleted = false,
                    CreatedTime = DateTime.Now,
                    CategoryId = 2
                });
        }
    }
}
