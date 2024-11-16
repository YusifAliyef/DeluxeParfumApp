using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeluxeParfum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderContriller : ApiControllerBase
    {
        public OrderContriller(IMediator mediator) : base(mediator)
        {
        }


    }
}
