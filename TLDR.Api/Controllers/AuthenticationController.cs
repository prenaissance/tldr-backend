using MediatR;
using Microsoft.AspNetCore.Mvc;
using TLDR.Application.Authentication.Commands.Login;
using TLDR.Application.Authentication.Dtos;

namespace TLDR.Api.Controllers
{

    [ApiController]
    [Route("api/auth/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDto user)
        {
            return Ok(await _mediator.Send(new LoginCommand(user)));
        }
    }

}