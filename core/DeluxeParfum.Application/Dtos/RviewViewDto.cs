using DeluxeParfum.Application.Mappers;
using DeluxeParfum.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Dtos
{
    public class RviewViewDto:IMapTo<Review>
    {
        public double ReviewPoint { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
