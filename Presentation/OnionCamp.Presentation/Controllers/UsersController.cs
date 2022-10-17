using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionCamp.Application.Features.Commands.AppUser.CreateUser;
using OnionCamp.Application.Features.Commands.AppUser.FacebookLogin;
using OnionCamp.Application.Features.Commands.AppUser.GoogleLogin;
using OnionCamp.Application.Features.Commands.AppUser.LoginUser;

namespace OnionCamp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }
    }
}
