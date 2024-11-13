using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Products.Update
{
    public class UpdateReviewCommand:IRequest
    {
        public int Id { get; set; }
        public double ReviewPoint { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
