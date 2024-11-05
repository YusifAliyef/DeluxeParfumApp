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
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductViewDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;

        }
        public async Task<IEnumerable<ProductViewDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _uow.ProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductViewDto>>(products);
        }
    }
}