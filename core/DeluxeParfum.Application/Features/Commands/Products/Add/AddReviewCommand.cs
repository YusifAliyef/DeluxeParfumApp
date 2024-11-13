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
    public class AddReviewCommand:IMapTo<Review>,IRequest
    {
        public double ReviewPoint { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
