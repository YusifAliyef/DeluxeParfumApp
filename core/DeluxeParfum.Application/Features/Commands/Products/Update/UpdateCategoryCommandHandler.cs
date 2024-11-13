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

namespace DeluxeParfum.Application.Features.Commands.Products.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<UpdateCategoryCommand> _validationRules;

        public UpdateCategoryCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<UpdateCategoryCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var categoryDetail =  _mapper.Map<Category>(request);

            var editedCategory = await _uow.CategoryRepository.GetByIdAsync(request.Id);

            editedCategory.Value = request.Value;

            await _uow.Commit();
           
        }
    }
}
