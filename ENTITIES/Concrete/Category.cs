using SHARED.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public string Name { get; set; }

        //Relation with Product (One-to-Many)
        public ICollection<Product> Products { get; set; }
    }
}
