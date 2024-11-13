using DeluxeParfum.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Query.Products
{
    public class GetAllAddressQuery : IRequest<IEnumerable<AddressViewDto>>
    {
    }
}
