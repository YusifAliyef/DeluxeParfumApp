using DeluxeParfum.Api;
using DeluxeParfum.Application.Dtos;
using DeluxeParfum.Application.Features.Commands.Products.Add;
using DeluxeParfum.Application.Features.Commands.Products.Delete;
using DeluxeParfum.Application.Features.Commands.Products.Update;
using DeluxeParfum.Application.Features.Query.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeluxeParfum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        public ProductController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ActionName("products")]

        public async Task<ActionResult<ApiResponseModel<IEnumerable<ProductViewDto>>>> GetProductAsync()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return await SuccessResult("Product data is selected", products);
        }

        [HttpPost]
        [ActionName("products")]

        public async Task<ActionResult<ApiResponseModel<string>>> AddProducts(AddProductsCommand command)
        {
            await _mediator.Send(command);
            return await SuccessResult<string>("Product added successfully");
        }

        [HttpPut]
        [ActionName("products")]
        public async Task<ActionResult<ApiResponseModel<string>>> UpdateProduct(UpdateProductCommand command)
        {
            var user = User;
            await _mediator.Send(command);
            return await SuccessResult<string>("Product updated successfully");
        }

        [HttpDelete("{id}")]
        [ActionName("products")]
        public async Task<ActionResult<ApiResponseModel<string>>> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return await SuccessResult<string>("Product deleted successfully");
        }



    }
}
