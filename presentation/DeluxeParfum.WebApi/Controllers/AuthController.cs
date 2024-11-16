using DeluxeParfum.Api;
using DeluxeParfum.Application.Dtos;
using DeluxeParfum.Application.Features.Commands;
using DeluxeParfum.Application.Features.Commands.Account;
using DeluxeParfum.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiorParfum.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AuthController : ApiControllerBase
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ActionName("SignUp")]
        public async Task<ActionResult<ApiResponseModel<AuthenticatedUserDto>>> Register(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return await SuccessResult("Token generated successfully", result);
        }

        [HttpPost]
        [ActionName("SignIn")]
        public async Task<ActionResult<ApiResponseModel<AuthenticatedUserDto>>> Login(GenerateTokenCommand command)
        {
            var result = await _mediator.Send(command);

            return await SuccessResult("Token generated successfully", result);
        }

    }
}
