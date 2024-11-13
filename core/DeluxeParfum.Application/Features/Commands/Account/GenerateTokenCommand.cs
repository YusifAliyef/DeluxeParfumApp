using DeluxeParfum.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Account
{
    public class GenerateTokenCommand : IRequest<AuthenticatedUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}