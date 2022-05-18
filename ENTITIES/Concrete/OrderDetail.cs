using SHARED.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Concrete
{
    public class OrderDetail : EntityBase, IEntity
    {
        public Guid ProductId { get; set; }
        public int Piece { get; set; }

        //Relation with Order (One-to-Many)
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
