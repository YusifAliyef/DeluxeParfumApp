using DeluxeParfum.Application.Features.Commands.Account;
using DeluxeParfum.Application.Features.Commands.Products.Add;
using DeluxeParfum.Application.Features.Commands.Products.Delete;
using DeluxeParfum.Application.Features.Commands.Products.Update;
using DeluxeParfum.Application.Validators.AddValidators;
using DeluxeParfum.Application.Validators.DeleteValidators;
using DeluxeParfum.Application.Validators.UpdateValidator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddScoped(typeof(AbstractValidator<AddAddressCommand>), typeof(AbstractValidator<AddAddressCommandValidator>));
            services.AddScoped(typeof(AbstractValidator<UpdateAddressCommand>), typeof(AbstractValidator<UpdateAddressCommandValidator>));
            services.AddScoped(typeof(AbstractValidator<DeleteAddressCommand>), typeof(AbstractValidator<DeleteAddressCommandValidator>));

            services.AddScoped(typeof(AbstractValidator<CreateUserCommand>), typeof(AbstractValidator<CreateUserCommandValidator>));

            services.AddScoped(typeof(AbstractValidator<AddRoleCommand>), typeof(AbstractValidator<AddRoleCommandValidation>));
            services.AddScoped(typeof(AbstractValidator<UpdateRoleCommand>), typeof(AbstractValidator<UpdateRoleCommandValidation>));
            services.AddScoped(typeof(AbstractValidator<DeleteRoleCommand>), typeof(AbstractValidator<DeleteRoleCommandValidation>));

            services.AddScoped(typeof(AbstractValidator<AddProductsCommand>), typeof(AbstractValidator<AddProductCommandValidator>));
            services.AddScoped(typeof(AbstractValidator<UpdateProductCommand>), typeof(AbstractValidator<UpdateProductCommandValidator>));
            services.AddScoped(typeof(AbstractValidator<DeleteProductCommand>), typeof(AbstractValidator<DeleteProductCommandValidator>));

            services.AddScoped(typeof(AbstractValidator<AddCategoryCommand>), typeof(AbstractValidator<AddCategoryCommandValidator>));
            services.AddScoped(typeof(AbstractValidator<UpdateCategoryCommand>), typeof(AbstractValidator<UpdateCategoryCommandValidator>));
            services.AddScoped(typeof(AbstractValidator<DeleteCategoryCommand>), typeof(AbstractValidator<DeleteCategoryCommandValidator>));

            services.AddScoped(typeof(AbstractValidator<AddCustomerCommand>), typeof(AbstractValidator<AddCustomerCommandValidation>));
            services.AddScoped(typeof(AbstractValidator<UpdateCustomerCommand>), typeof(AbstractValidator<UpdateCustomerCommandValidator>));
            services.AddScoped(typeof(AbstractValidator<DeleteCustomerCommand>), typeof(AbstractValidator<DeleteCustomerCommandValidator>));

            services.AddScoped(typeof(AbstractValidator<AddOrderCommand>), typeof(AbstractValidator<AddOrderCommandValidator>));
            services.AddScoped(typeof(AbstractValidator<UpdateOrderCommand>), typeof(AbstractValidator<UpdateOrderCommandValidator>));
            services.AddScoped(typeof(AbstractValidator<DeleteOrderCommand>), typeof(AbstractValidator<DeleteOrderCommandValidator>));

            services.AddScoped(typeof(AbstractValidator<AddReviewCommand>), typeof(AbstractValidator<AddReviewCommandValidation>));
            services.AddScoped(typeof(AbstractValidator<UpdateReviewCommand>), typeof(AbstractValidator<UpdateReviewCommandValidaton>));
            services.AddScoped(typeof(AbstractValidator<DeleteReviewCommand>), typeof(AbstractValidator<DeleteReviewCommandValidation>));




        }
    }
}
