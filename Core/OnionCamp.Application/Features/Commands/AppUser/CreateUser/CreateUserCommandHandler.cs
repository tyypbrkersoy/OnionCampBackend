using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionCamp.Application.Abstractions.Services;
using OnionCamp.Application.DTOs.User;
using OnionCamp.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = OnionCamp.Domain.Entities.Identity;


namespace OnionCamp.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                UserName = request.UserName,
            });

            return new()
            {
                Message=response.Message,
                Succedded=response.Succedded,
            };
        }
    }
}
