using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionCamp.Application.Abstractions.Services;
using OnionCamp.Application.Abstractions.Token;
using OnionCamp.Application.DTOs;
using OnionCamp.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = OnionCamp.Domain.Entities.Identity;

namespace OnionCamp.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {

            var token = await _authService.LoginAsync(request.UserNameOrEmail,request.Password, 15);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token,
            };
        }
    }
}
