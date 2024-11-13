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
    public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, IEnumerable<RviewViewDto>>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllReviewQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public  async Task<IEnumerable<RviewViewDto>> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
        {
            var products = await _uow.ReviewRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RviewViewDto>>(products);
        }
    }
}
