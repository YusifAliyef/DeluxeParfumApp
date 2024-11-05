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
    public class AddAddressCommand:IMapTo<Address>,IRequest
    {
        public string CityName { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }

    }
}
