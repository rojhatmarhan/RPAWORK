using SHARED.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Concrete
{
    public class Product : EntityBase, IEntity
    {
        public string Name { get; set; }
        public Guid Code { get; set; }  = Guid.NewGuid();
        public decimal Price { get; set; }

        //Relation with Category(one-to-Many)
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
