using SHARED.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Concrete
{
    public class Order : EntityBase, IEntity
    {
        public string? Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        //Relation with User(One-to-Many)
        public Guid UserId { get; set; }
        public User User { get; set; }

        //Relation with OrderDetail(One-to-Many)
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
