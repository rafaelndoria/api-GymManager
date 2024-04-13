using GymManager.Application.Commands.ActivateCustomer;
using GymManager.Application.Commands.CreateCustomer;
using GymManager.Application.Commands.InactivateCustomer;
using GymManager.Application.Commands.UpdateCustomer;
using GymManager.Application.Queries.GetAllCustomers;
using GymManager.Application.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerCommand command)
        {
            command.Id = id;
            var updated = await _mediator.Send(command);
            if (!updated)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("inactivate/{id}")]
        public async Task<IActionResult> Inactivate(int id)
        {
            var command = new InactivateCustomerCommand(id);
            var inactivated = await _mediator.Send(command);
            if (!inactivated)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> Activate(int id)
        {
            var command = new ActivateCustomerCommand(id);
            var activated = await _mediator.Send(command);
            if (!activated)
                return BadRequest();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCustomerByIdQuery(id);
            var customerViewModel = await _mediator.Send(query.Id);
            if (customerViewModel == null)
                return NotFound();
            return Ok(customerViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var query = new GetAllCustomerQuery();
            var customers = await _mediator.Send(query);
            return Ok(customers);
        }
    }
}
