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
    public class PlacementController : ControllerBase
    {
        private readonly IPlacementRepository Repository;

        public PlacementController(IPlacementRepository repo)
        {
            Repository = repo;
        }


        [HttpGet("{id}", Name = "GetPlacement")]
        public async Task<ActionResult<PlacementReadDTO>> GetPlacement(int id)
        {
            var placement = await Repository.ReadAsync(id);

            if (placement != null) return placement;
            else return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<List<PlacementReadDTO>>> GetPlacements()
        {
            var placements = await Repository.ReadAllAsync();
            return placements;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlacementCreateDTO placement)
        {
            var id = await Repository.CreateAsync(placement);

            if (id == -1) return NoContent();
            return CreatedAtAction(nameof(GetPlacement), new { id }, default);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlacementUpdateDTO placement)
        {
            var updatedId = await Repository.UpdateAsync(id, placement);

            if (updatedId == -1) return NotFound();
            return Ok();
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