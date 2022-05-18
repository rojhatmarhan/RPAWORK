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
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> b)
        {
            //Common Area
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedOnAdd();

            b.Property(x => x.Piece).IsRequired();

            b.Property(x => x.ProductId).IsRequired();

            b.HasOne<Order>(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);

            b.ToTable("OrderDetails");

            b.HasData(new OrderDetail
            {
                Id = Guid.Parse("a0a9ee05-5cef-45c7-99f1-48f1145e8c48"),
                Piece = 13,
                ProductId = Guid.Parse("b2ea5779-f229-4c45-b565-553dd05aa079"),
                OrderId = Guid.Parse("f188baed-84d3-423e-86fe-a442a2f5988f")
            },
            new OrderDetail
            {
                Id = Guid.Parse("61064396-2770-41dd-9075-c83bfee5b8f5"),
                Piece = 13,
                ProductId = Guid.Parse("0df308d6-1d62-49f8-b87d-45121a8fb087"),
                OrderId = Guid.Parse("f188baed-84d3-423e-86fe-a442a2f5988f")
            },
            new OrderDetail
            {
                Id = Guid.Parse("1e0ca3a5-cfe2-4bea-98a7-b67ff7cc8474"),
                Piece = 13,
                ProductId = Guid.Parse("b2ea5779-f229-4c45-b565-553dd05aa079"),
                OrderId = Guid.Parse("fe63088f-6578-4ffe-aa9e-bf47bcc5fc21")
            },
            new OrderDetail
            {
                Id = Guid.Parse("fd690002-7283-45d3-91a3-4d4fee7960db"),
                Piece = 13,
                ProductId = Guid.Parse("a4436498-5dd2-49f4-a83c-850c8e46eaab"),
                OrderId = Guid.Parse("d09978fd-3031-40dd-b6fb-bcc0cc368572")
            });
        }
    }
}
