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
    public class GetAllOrderCommandHandler : IRequestHandler<GetAllOrderCommand, IEnumerable<OrderViewDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllOrderCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<IEnumerable<OrderViewDto>> Handle(GetAllOrderCommand request, CancellationToken cancellationToken)
        {
            var customers = await _uow.OrderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderViewDto>>(customers);
        }
    }
}
