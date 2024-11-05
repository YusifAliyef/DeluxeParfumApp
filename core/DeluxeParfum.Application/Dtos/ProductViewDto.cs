using DeluxeParfum.Application.Mappers;
using DeluxeParfum.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Dtos
{
    public class ProductViewDto:IMapTo<Product>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
    }
}
