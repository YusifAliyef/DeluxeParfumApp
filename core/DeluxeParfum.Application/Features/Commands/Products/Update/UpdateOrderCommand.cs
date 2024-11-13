using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Products.Update
{
    public class UpdateOrderCommand:IRequest
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public OrderStatus CommitOrder { get; set; }
        public enum OrderStatus
        {
            Pending,
            Completed,
            Cancelled
        }
        public int CustomerId { get; set; }
    }
}
