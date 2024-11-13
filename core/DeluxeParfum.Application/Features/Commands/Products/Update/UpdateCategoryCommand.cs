using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Products.Update
{
    public class UpdateCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
