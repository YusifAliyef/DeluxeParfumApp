using AutoMapper;
using DeluxeParfum.Application.Extensions;
using DeluxeParfum.Application.Interfaces;
using DeluxeParfum.Domain.Entities.Products;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Products.Add
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddCategoryCommand> _validationRules;

        public AddCategoryCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddCategoryCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var categoryEntity = _mapper.Map<Category>(request);
            await _uow.CategoryRepository.AddAsync(categoryEntity);
            await _uow.Commit();
        }
    }
}
