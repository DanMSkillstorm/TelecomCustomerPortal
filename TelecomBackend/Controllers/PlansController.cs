using Microsoft.AspNetCore.Mvc;
using TelecomBackend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelecomBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        #region CREATE CONTEXT
        private readonly IPlansCosmosDbService _context;

        public PlansController(IPlansCosmosDbService context)
        {
            _context = context;
        }
        #endregion

        // GET: api/<PlansController>
        [HttpGet("{id}")]
        public async Task<IEnumerable<Plan>> GetPlansByAccount(string id)
        {
            var plans = await _context.GetPlansAsync(id);
            return plans;
        }

        // GET api/<PlansController>/5
        [HttpGet("{id}/PlanId/{planId}")]
        public async Task<Plan> GetPlan(string id, string planId)
        {
            Plan plan = await _context.GetPlanAsync(id, planId);
            return plan;
        }

        // POST api/<PlansController>
        [HttpPost("{id}")]
        public async Task<ActionResult> AddPlan(string id, PlanDTO planDTO)
        {
            await _context.AddPlanAsync(id, planDTO);
            return NoContent();
        }

        // DELETE api/<PlansController>/5
        [HttpDelete("{accountId}/plan/{id}")]
        public async Task<ActionResult> DeletePlan(string id, string accountId)
        {
            await _context.DeletePlanAsync(id, accountId);
            return NoContent();
        }
    }
}
