using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
//using Newtonsoft.Json;
using System.Text.Json;
using OnionCamp.Application.Abstractions.Token;
using OnionCamp.Application.DTOs;
using OnionCamp.Application.DTOs.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = OnionCamp.Domain.Entities.Identity;
using OnionCamp.Application.Abstractions.Services;

namespace OnionCamp.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public FacebookLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.FacebookLoginAsync(request.AuthToken, 15);
            return new()
            {
                Token=token
            };
        }
    }
}
