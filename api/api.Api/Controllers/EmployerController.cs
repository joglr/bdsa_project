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
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerRepository Repository;

        public EmployerController(IEmployerRepository repo)
        {
            Repository = repo;
        }


        [HttpGet("{id}", Name = "GetEmployer")]
        public async Task<ActionResult<EmployerReadDTO>> GetEmployer(int id)
        {
            var employer = await Repository.ReadAsync(id);

            if (employer != null) return employer;
            else return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployerReadDTO>>> GetEmployers()
        {
            var employer = await Repository.ReadAllAsync();
            return employer;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployerCreateDTO employer)
        {
            var id = await Repository.CreateAsync(employer);

            return CreatedAtAction(nameof(GetEmployer), new { id }, default);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removedId = await Repository.DeleteAsync(id);

            if (removedId == -1) return NotFound();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployerUpdateDTO employer)
        {
            var updatedId = await Repository.UpdateAsync(id, employer);

            if (updatedId == -1) return NotFound();
            return Ok();
        }
    }
}