using DeluxeParfum.Application.Mappers;
using DeluxeParfum.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Dtos
{
    public class CategoryViewDto:IMapTo<Category>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
