using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;
using api.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace api.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CapabilityController : ControllerBase
    {
        private readonly ICapabilityRepository Repository;

        public CapabilityController(ICapabilityRepository repo)
        {
            Repository = repo;
        }


        [HttpGet("{id}", Name = "GetCapability")]
        public async Task<ActionResult<CapabilityReadDTO>> GetCapability(int id)
        {
            var capability = await Repository.ReadAsync(id);

            if (capability != null) return capability;
            else return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<List<CapabilityReadDTO>>> GetCapabilities()
        {
            var capabilities = await Repository.ReadAllAsync();
            return capabilities;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CapabilityCreateDTO capability)
        {
            var id = await Repository.CreateAsync(capability);

            return CreatedAtAction(nameof(GetCapability), new { id }, default);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removedId = await Repository.DeleteAsync(id);

            if (removedId == -1) return NotFound();
            return Ok();
        }
    }
}