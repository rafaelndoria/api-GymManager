using GymManager.Application.Commands.ActivatePlan;
using GymManager.Application.Commands.AddPlanTime;
using GymManager.Application.Commands.CreatePlan;
using GymManager.Application.Commands.DeletePlanTime;
using GymManager.Application.Commands.InactivatePlan;
using GymManager.Application.Commands.UpdatePlan;
using GymManager.Application.Commands.UpdatePlanTime;
using GymManager.Application.Queries.GetAllDayOfWeek;
using GymManager.Application.Queries.GetAllPlans;
using GymManager.Application.Queries.GetAllPlansType;
using GymManager.Application.Queries.GetDetailsPlan;
using GymManager.Application.Queries.GetPlanById;
using GymManager.Application.Queries.GetPlanTimeByIdPlan;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/plans")]
    [Authorize(Roles = "admin, manager")]
    public class PlanController : ControllerBase
    {
        private readonly IMediator _meadiator;

        public PlanController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPlans(string? query)
        {
            var querySend = new GetAllPlansQuery(query);
            var plans = await _meadiator.Send(querySend);
            return Ok(plans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanById(int id)
        {
            var querySend = new GetPlanByIdQuery(id);
            var plan = await _meadiator.Send(querySend);
            if (plan == null)
                return NotFound();
            return Ok(plan);
        }

        [HttpGet("details/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetPlanDetails(int id)
        {
            var querySend = new GetDetailsPlanQuery(id);
            var planDetails = await _meadiator.Send(querySend);
            if (planDetails == null)
                return NotFound();
            return Ok(planDetails);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetAllPlansType()
        {
            var querySend = new GetAllPlansTypeQuery("");
            var plansType = await _meadiator.Send(querySend);
            return Ok(plansType);
        }

        [HttpGet("times/{id}")]
        public async Task<IActionResult> GetPlanTimeByIdPlan(int id)
        {
            var querySend = new GetPlanTimeByIdPlanQuery(id);
            var planTimes = await _meadiator.Send(querySend);
            if (planTimes == null)
                return NotFound();
            return Ok(planTimes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlanCommand command)
        {
            var planId = await _meadiator.Send(command);
            if (planId == 0)
                return BadRequest();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePlanCommand command)
        {
            command.Id = id;
            var updated = await _meadiator.Send(command);
            if (!updated)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("inactivate/{id}")]
        public async Task<IActionResult> InactivatePlan(int id)
        {
            var command = new InactivatePlanCommand(id);
            var inactivated = await _meadiator.Send(command);
            if (!inactivated)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivatePlan(int id)
        {
            var command = new ActivatePlanCommand(id);
            var activated = await _meadiator.Send(command);
            if (!activated)
                return BadRequest();
            return NoContent();
        }

        [HttpPost("times")]
        public async Task<IActionResult> AddPlanTime(AddPlanTimeCommand command)
        {
            var added = await _meadiator.Send(command);
            if (!added)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("times/{id}")]
        public async Task<IActionResult> UpdatePlanTime(int id, UpdatePlanTimeCommand command)
        {
            command.PlanTimeId = id;
            var updated = await _meadiator.Send(command);
            if (!updated)
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("times/{id}")]
        public async Task<IActionResult> DeletePlanTime(int id)
        {
            var command = new DeletePlanTimeCommand(id);
            var deleted = await _meadiator.Send(command);
            if (!deleted)
                return BadRequest();
            return NoContent();
        }

        [HttpGet("week")]
        public async Task<IActionResult> GetDayOfWeek()
        {
            var query = new GetAllDayOfWeekQuery();
            var daysOfWeek = await _meadiator.Send(query);
            return Ok(daysOfWeek);
        }
    }
}
