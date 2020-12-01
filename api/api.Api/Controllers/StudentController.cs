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


        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<ActionResult<StudentReadDTO>> GetStudent(int id)
        {
            var student = await Repository.ReadAsync(id);

            if (student != null) return student;
            else return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentReadDTO>>> GetStudents()
        {
            var students = await Repository.ReadAllAsync();
            return students;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateDTO student)
        {
            var id = await Repository.CreateAsync(student);

            return CreatedAtAction(nameof(GetStudent), new { id }, default);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removedId = await Repository.DeleteAsync(id);

            if (removedId == -1) return NotFound();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentUpdateDTO student)
        {
            var updatedId = await Repository.UpdateAsync(id, student);

            if (updatedId == -1) return NotFound();
            return Ok();
        }
    }
}