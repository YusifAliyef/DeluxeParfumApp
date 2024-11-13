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
    public class AddOrderCommand:IMapTo<Order>, IRequest
    {
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
