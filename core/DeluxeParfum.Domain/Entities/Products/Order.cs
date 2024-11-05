using DeluxeParfum.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Domain.Entities.Products
{
    public class Order:BaseEntity
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        public int Quantity { get; set; }
        public OrderStatus CommitOrder { get; set; }
        public enum OrderStatus
        {
            Pending,
            Completed,
            Cancelled
        }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }

    }
}
