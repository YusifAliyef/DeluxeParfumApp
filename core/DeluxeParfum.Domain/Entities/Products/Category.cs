using DeluxeParfum.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Domain.Entities.Products
{
    public class Category:EditedBaseEntity
    {
        public Category()
        {
            Products=new HashSet<Product>();    
        }
        public string Value { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
