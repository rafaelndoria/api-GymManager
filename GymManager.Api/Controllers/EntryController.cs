using GymManager.Application.Commands.EntryCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/entries")]
    [Authorize]
    public class EntryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> MovementCustomer(EntryCustomerCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // listar entradas
        // validacoes 
    }
}
