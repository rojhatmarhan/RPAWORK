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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
            //Common Area
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedOnAdd();

            b.Property(x => x.Name).IsRequired();
            b.Property(x => x.Name).HasMaxLength(250);
            b.Property(x => x.Code).IsRequired();
            b.Property(x => x.Price).IsRequired();

            b.HasOne<Category>(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            b.ToTable("Products");

            b.HasData(new Product
            {
                Id = Guid.Parse("b2ea5779-f229-4c45-b565-553dd05aa079"),
                Name = "HP Smart Tank 519 3YW73A Wi-Fi + Fotokopi + Tarayıcı Renkli",
                CategoryId = Guid.Parse("7c9cbfed-26f3-4063-9d41-0306f1eae424"),
                Code = Guid.Parse("11ca2893-a0fe-4286-bb15-bad66730e45e"),
                Price = (decimal)1300.13
            }, 
            new Product
            {
                Id = Guid.Parse("0df308d6-1d62-49f8-b87d-45121a8fb087"),
                Name = "Samsung Xpress Sl M2020-2070Fw - Mlt D111S Muadil Toneri - Çipli",
                CategoryId = Guid.Parse("7c9cbfed-26f3-4063-9d41-0306f1eae424"),
                Code = Guid.Parse("17e2c381-beb8-4419-b821-10c9c4d111b4"),
                Price = (decimal)1300.13
            },
            new Product
            {
                Id = Guid.Parse("f5d2ca2d-df60-421b-9a2b-2c957c258eb3"),
                Name = "Huawei Matebook D15 Intel Core i7 1165G7 16GB 512GB SSD Windows 11 Home 15.6' Taşınabilir Bilgisayar",
                CategoryId = Guid.Parse("7c9cbfed-26f3-4063-9d41-0306f1eae424"),
                Code = Guid.Parse("2ac0910b-5462-426a-8ecb-01639f8314af"),
                Price = (decimal)1300.13
            },
            new Product
            {
                Id = Guid.Parse("a4436498-5dd2-49f4-a83c-850c8e46eaab"),
                Name = "Grundig GWM 91014 A 9 kg 1000 Devir Bluetooth Bağlantılı Çamaşır Makinesi",
                CategoryId = Guid.Parse("41a85ed5-793d-48f3-b42d-2df20ec08626"),
                Code = Guid.Parse("a7e827ed-3a8b-4213-bcfa-1b66819d1739"),
                Price = (decimal)1300.13
            });
        }
    }
}
