using GymManager.Application.Commands.ActivateUser;
using GymManager.Application.Commands.CreateUser;
using GymManager.Application.Commands.InactivateUser;
using GymManager.Application.Commands.LoginUser;
using GymManager.Application.Commands.UpdateUser;
using GymManager.Application.Queries.GetAllUsers;
using GymManager.Application.Queries.GetUserById;
using GymManager.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize(Roles = "admin, manager")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var token = await _mediator.Send(command);
            return StatusCode(201, new TokenViewModel(token));
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var token = await _mediator.Send(command);
            if (token == null)
                return Unauthorized();
            return Ok(new TokenViewModel(token));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command) 
        {
            var updated = await _mediator.Send(command);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateUserCommand(id);
            var activated = await _mediator.Send(command) ;
            if (!activated)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("inactivate/{id}")]
        public async Task<IActionResult> Incativate(int id)
        {
            var command = new InactivateUserCommand(id);
            var inactivated = await _mediator.Send(command);
            if (!inactivated)
                return BadRequest();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetUserByIdQuery(id);
            var user = await _mediator.Send(command);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? query)
        {
            var command = new GetAllUsersQuery(query);
            var users = await _mediator.Send(command);
            return Ok(users);
        }
    }
}
