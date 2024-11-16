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
    public class AddressController : ApiControllerBase
    {
        public AddressController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ActionName("addresses")]

        public async Task<ActionResult<ApiResponseModel<IEnumerable<AddressViewDto>>>> GetaddressAsync()
        {
            var addresses = await _mediator.Send(new GetAllAddressQuery());
            return await SuccessResult("Address data is retrieved", addresses );
        }

        [HttpPost]
        [ActionName("addresses")]

        public async Task<ActionResult<ApiResponseModel<string>>> AddAddress(AddAddressCommand command)
        {
            await _mediator.Send(command);
            return await SuccessResult<string>("Address added successfully");
        }

        [HttpPut]
        [ActionName("addresses")]

        public async Task<ActionResult<ApiResponseModel<string>>> UpdateAddress(UpdateAddressCommand command)
        {
            var user = User;
            await _mediator.Send(command);
            return await SuccessResult<string>("Address updated successfully");
        }

        [HttpDelete("{id}")]
        [ActionName("addresses")]

        public async Task<ActionResult<ApiResponseModel<string>>> DeleteAddress(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return await SuccessResult<string>("Address deleted successfully");
        }


    }
}
