using DeluxeParfum.Application.Mappers;
using DeluxeParfum.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Dtos
{
    public class OrderViewDto:IMapTo<Order>
    {
        public int Quantity { get; set; }
       
        public int CustomerId { get; set; }
    }
}
