using GymManager.Application.Commands.ActiveSubscription;
using GymManager.Application.Commands.BlockSubscription;
using GymManager.Application.Commands.RenewSubscription;
using GymManager.Application.Commands.StartSubscription;
using GymManager.Application.Queries.GetAllSubscriptions;
using GymManager.Application.Queries.GetSubscriptionById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/subscriptions")]
    [Authorize]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("start/{customerId:int}")]
        public async Task<IActionResult> StartSubscription(int customerId, StartSubscriptionCommand command)
        {
            try
            {
                command.CustomerId = customerId;
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("renew/{customerId:int}")]
        public async Task<IActionResult> RenewSubscription(int customerId, RenewSubscriptionCommand command)
        {
            try
            {
                command.CustomerId = customerId;
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("block/{customerId:int}")]
        public async Task<IActionResult> BlockSubscription(int customerId)
        {
            try
            {
                var command = new BlockSubscriptionCommand(customerId);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("active/{customerId:int}")]
        public async Task<IActionResult> ActiveSubscription(int customerId)
        {
            try
            {
                var command = new ActiveSubscriptionCommand(customerId);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? inputQuery)
        {
            var query = new GetAllSubscriptionQuery(inputQuery);
            var subscriptions = await _mediator.Send(query);
            return Ok(subscriptions);
        }

        [HttpGet("{subscriptionId:int}")]
        public async Task<IActionResult> GetById(int subscriptionId)
        {
            var query = new GetSubscriptionByIdQuery(subscriptionId);
            var subscription = await _mediator.Send(query);
            return Ok(subscription);
        }
    }
}
