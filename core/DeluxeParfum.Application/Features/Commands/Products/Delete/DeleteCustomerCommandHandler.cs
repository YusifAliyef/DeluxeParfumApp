using AutoMapper;
using DeluxeParfum.Application.Extensions;
using DeluxeParfum.Application.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Products.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<DeleteCustomerCommand> _validationRules;

        public DeleteCustomerCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<DeleteCustomerCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var categoriesEntity = await _uow.CustomerRepository.GetByIdAsync(request.Id);
            if (categoriesEntity == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }

            _uow.CustomerRepository.Remove(categoriesEntity);
            await _uow.Commit();

        }
    }
}
