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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> b)
        {
            //Common Area
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedOnAdd();

            b.Property(x => x.Description).IsRequired(false);
            b.Property(x => x.Date).IsRequired();

            b.HasOne<User>(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);

            b.ToTable("Orders");

            b.HasData(new Order
            {
                Id = Guid.Parse("f188baed-84d3-423e-86fe-a442a2f5988f"),
                Date = DateTime.Now,
                UserId = Guid.Parse("1edd49c1-c4ad-493b-8b9e-25609cbeea18"),
                Description = "user1 first order"
            },
            new Order
            {
                Id = Guid.Parse("fe63088f-6578-4ffe-aa9e-bf47bcc5fc21"),
                Date = DateTime.Now,
                UserId = Guid.Parse("e44e664a-bb62-486d-984b-5aab43837d58"),
                Description = "user2 first order"
            },
            new Order
            {
                Id = Guid.Parse("d09978fd-3031-40dd-b6fb-bcc0cc368572"),
                Date = DateTime.Now,
                UserId = Guid.Parse("e44e664a-bb62-486d-984b-5aab43837d58"),
                Description = "user2 second order"
            });
        }
    }
}
