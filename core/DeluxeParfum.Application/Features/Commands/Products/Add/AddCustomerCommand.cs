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
    public class AddCustomerCommand:IMapTo<Customer>,IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? AddressId { get; set; }
    }
}
