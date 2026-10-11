using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_ManagementDemo.AllDTOs.StudentDTOs;
using School_ManagementDemo.Models;
using School_ManagementDemo.Unit_Of_Works;

namespace School_ManagementDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public StudentsController(IUnitOfWork u)
        {
            _unitofwork = u;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudent dto)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var e =  new Student
            {
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                Email = dto.Email,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber
            };
            _unitofwork.student.add(e);
            _unitofwork.Save();
            return Created("", e);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var t = await _unitofwork.student.GetAll();
            return Ok(t);
        }
        [HttpGet("By_Id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var t =  await _unitofwork.student.GetById(id);
            return Ok(t);
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> Edit(int id, [FromBody] CreateStudent dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = await _unitofwork.student.GetById(id);
            if (existing == null)
            {
                return NotFound("Not found");
            }

            existing.FullName = dto.FullName;
            existing.PhoneNumber = dto.PhoneNumber;
            existing.Email = dto.Email;
            existing.DateOfBirth = dto.DateOfBirth;
         
            _unitofwork.student.Update(existing); 

            await _unitofwork.Save(); 

            return NoContent(); 
        }


        [HttpGet("Search")]
        public async Task<IActionResult> Searchh(string Name)
        {
            var r =  _unitofwork.student.Search(Name);
            return Ok(r);
        }


        [HttpGet("Filter")]
        public async Task<IActionResult> filter(string Name)
        {
            var r = _unitofwork.student.Filter(Name);
            return Ok(r);
        }


        [HttpGet("Pagination")]
        public async Task<IActionResult> pAGI(int Pgenumber , int pagesize)
        {
            var r = _unitofwork.student.pagination(Pgenumber, pagesize);
            return Ok(r);
        }



    }
}
