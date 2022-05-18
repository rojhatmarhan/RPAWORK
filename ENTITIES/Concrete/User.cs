using SHARED.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Concrete
{
    public class User : EntityBase, IEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Guid? Session { get; set; }
        public int? Age { get; set; }

        //Relation with Category(One-to-Many)
        public ICollection<Order> Orders { get; set; }
    }
}