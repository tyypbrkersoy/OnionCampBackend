using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionCamp.Application.Abstractions.Services;
using OnionCamp.Application.DTOs.User;
using OnionCamp.Application.Features.Commands.AppUser.CreateUser;
using OnionCamp.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCamp.Persistance.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                NameSurname = model.Name,

            }, model.Password);

            CreateUserResponse response = new() { Succedded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı oluşturuldu";

            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}<br>";
                }
            }
            return response;

        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTime)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate= accessTokenDate.AddMinutes(refreshTokenLifeTime);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new Exception("Hata!");
        }
    }
}
