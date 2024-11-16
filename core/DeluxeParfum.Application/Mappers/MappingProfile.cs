using AutoMapper;
using DeluxeParfum.Application.Dtos;
using DeluxeParfum.Application.Features.Commands.Account;
using DeluxeParfum.Application.Features.Commands.Products.Add;
using DeluxeParfum.Application.Features.Commands.Products.Delete;
using DeluxeParfum.Application.Features.Commands.Products.Update;
using DeluxeParfum.Domain.Entities.Accounts;
using DeluxeParfum.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //For User
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateUserCommand, UserDetail>();


            CreateMap<AddAddressCommand, Address>();


            //For Role
            CreateMap<Role, RoleViewDto>();
            CreateMap<AddRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
            CreateMap<DeleteRoleCommand, Role>();

            //For VacancyDetail
            CreateMap<ProductViewDto, Product>();
            CreateMap<Product, ProductViewDto>();
            CreateMap<AddProductsCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<DeleteProductCommand, Product>();

            //For Vacancy
            CreateMap<CategoryViewDto, Category>();
            CreateMap<AddCategoryCommand, Category>();
            CreateMap<DeleteCategoryCommand, Category>();
            CreateMap<Category, CategoryViewDto>();




        }
    }
}
