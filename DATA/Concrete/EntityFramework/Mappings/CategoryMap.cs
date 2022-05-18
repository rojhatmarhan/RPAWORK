using ENTITIES.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> b)
        {
            //Common Area
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedOnAdd();

            b.Property(x => x.Name).IsRequired();
            b.Property(x => x.Name).HasMaxLength(100);

            b.ToTable("Categories");

            b.HasData(new Category
            {
                Id = Guid.Parse("41a85ed5-793d-48f3-b42d-2df20ec08626"),
                Name = "Beyaz Eşya",
            },
            new Category
            {
                Id = Guid.Parse("7c9cbfed-26f3-4063-9d41-0306f1eae424"),
                Name = "Elektronik"
            },
            new Category
            {
                Id = Guid.Parse("85c50918-6ce0-4531-b308-2e524ac63c3a"),
                Name = "Kozmetik"
            });
        }
    }
}
