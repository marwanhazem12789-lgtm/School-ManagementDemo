using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_ManagementDemo.AllDTOs.StudentDTOs;
using School_ManagementDemo.Models;
using School_ManagementDemo.Unit_Of_Works;

namespace School_ManagementDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeachersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.teacher.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AllDTOs.TeacherDTOs.CreateTeacher dto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var e = new Teacher
            {
                FullName = dto.FullName,
                HireDate = dto.HireDate,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };
            _unitOfWork.teacher.add(e);
            _unitOfWork.Save();
            return Created("", e);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] AllDTOs.TeacherDTOs.CreateTeacher dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = await _unitOfWork.teacher.GetById(id);
            if (existing == null)
            {
                return NotFound("Not found");
            }

            existing.FullName = dto.FullName;
            existing.PhoneNumber = dto.PhoneNumber;
            existing.Email = dto.Email;
            existing.HireDate = dto.HireDate;

            _unitOfWork.teacher.Update(existing);

            await _unitOfWork.Save();

            return NoContent();
        }

    }
}
