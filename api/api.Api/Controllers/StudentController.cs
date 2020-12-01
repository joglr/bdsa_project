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
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository Repository;

        public StudentController(IStudentRepository repo)
        {
            Repository = repo;
        }


        [HttpGet]
        public async Task<ActionResult<StudentReadDTO>> GetStudent(int id)
        {
            var student = await Repository.ReadAsync(id);

            if (student != null) return student;
            else return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateDTO student)
        {
            var id = await Repository.CreateAsync(student);

            return CreatedAtAction(nameof(GetStudent), new { id }, default);
        }
    }
}