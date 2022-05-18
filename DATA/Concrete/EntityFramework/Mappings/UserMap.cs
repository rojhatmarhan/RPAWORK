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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            //Common Area
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedOnAdd();

            b.Property(x => x.UserName).IsRequired();
            b.Property(x => x.UserName).HasMaxLength(50);

            b.Property(x => x.FirstName).IsRequired();
            b.Property(x => x.FirstName).HasMaxLength(50);

            b.Property(x => x.LastName).IsRequired();
            b.Property(x => x.LastName).HasMaxLength(50);

            b.Property(x => x.Session).IsRequired(false);

            b.Property(x => x.Age).IsRequired(false);

            b.ToTable("Users");

            b.HasData(new User
            {
                Id = Guid.Parse("1edd49c1-c4ad-493b-8b9e-25609cbeea18"),
                UserName = "user1",
                FirstName = "First UserName",
                LastName = "First LastName",
                Password = "24c9e15e52afc47c225b757e7bee1f9d",// MD5 -> user1 
                Age = 18
            },
            new User
            {
                Id = Guid.Parse("e44e664a-bb62-486d-984b-5aab43837d58"),
                UserName = "user2",
                FirstName = "Second UserName",
                LastName = "Second LastName",
                Password = "7e58d63b60197ceb55a1c487989a3720",// MD5 -> user2
                Age = 43
            });
        }
    }
}