using DeluxeParfum.Application.Mappers;
using DeluxeParfum.Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Products.Add
{
    public class AddCategoryCommand:IMapTo<Category>,IRequest
    {
        public string Value { get; set; }
    }
}
