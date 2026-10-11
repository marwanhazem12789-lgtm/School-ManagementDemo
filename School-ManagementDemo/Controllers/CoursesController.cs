using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_ManagementDemo.Models;
using School_ManagementDemo.Unit_Of_Works;

namespace School_ManagementDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            return Ok(await _unitOfWork.course.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Create(AllDTOs.CourseDTOs.CraeteCourse dto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var e = new Course
            {
                CreditHours = dto.CreditHours,
                TeacherId = dto.TeacherId,
                Title = dto.Title,
            };
            _unitOfWork.course.add(e);
            _unitOfWork.Save();
            return Created("", e);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] AllDTOs.CourseDTOs.CraeteCourse dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = await _unitOfWork.course.GetById(id);
            if (existing == null)
            {
                return NotFound("Not found");
            }

           existing.Title  = dto.Title;
            existing.CreditHours = dto.CreditHours;
            existing.TeacherId = dto.TeacherId;

            _unitOfWork.course.Update(existing);

            await _unitOfWork.Save();

            return NoContent();
        }


        [HttpGet("search")]
        public async Task<IActionResult> search(string name)
        {
            var e = _unitOfWork.course.
        }

    }
}
