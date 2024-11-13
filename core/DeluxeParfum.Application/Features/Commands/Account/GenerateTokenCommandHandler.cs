using DeluxeParfum.Application.Dtos;
using DeluxeParfum.Application.Exception;
using DeluxeParfum.Application.Helper;
using DeluxeParfum.Application.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Account
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, AuthenticatedUserDto>
    {
        private readonly IUnitOfWork _uow;

        public GenerateTokenCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        

        public async Task<AuthenticatedUserDto> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _uow.UserRepository.GetUserWithDetail(request.Email);

            if (user is null && HashHelper.VerifyPasswordHash(request.Password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PasswordSalt)))
            {
                throw new DeluxeParfumValidationException("Email or password is incorrect");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.UserDetail.FirstName),
                new Claim(ClaimTypes.Surname , user.UserDetail.LastName),
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticatedUserDto
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}