using AutoMapper;
using DeluxeParfum.Application.Dtos;
using DeluxeParfum.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Query.Products
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerViewDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerViewDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {

            var customers = await _uow.CustomerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerViewDto>>(customers);
        }
    }
}
