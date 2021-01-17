using generic_repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Data.EntityFramework.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Ekran Kartı",
                CreatedTime = DateTime.Now
            },
            new Category
            {
                Id = 2,
                Name = "İşlemci",
                CreatedTime = DateTime.Now
            });
        }
    }
}
