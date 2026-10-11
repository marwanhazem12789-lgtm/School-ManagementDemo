using School_ManagementDemo.Genarics;
using School_ManagementDemo.Models;


using School_ManagementDemo.Generics;
using School_ManagementDemo.AllDTOs.StudentDTOs;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace School_ManagementDemo.AllCustoms.StudentCustom
{
    public class StudentRepo : GenericRepo<Student>,  IStudentRepo
    {
        private readonly Context _context;
        public StudentRepo(Context c) : base(c)
        {
            _context = c;
        }

        public List<GetAllStudents> Filter(string Gender)
        {
            return _context.students.Where(i => i.Gender.Equals(Gender)).Select(i => new GetAllStudents
            {
                FullName = i.FullName,
                DateOfBirth = i.DateOfBirth,
                Email = i.Email,
                Gender = i.Gender,
                PhoneNumber = i.PhoneNumber,
            }).ToList();
        }

        public async Task<List<Student>> pagination(int PageNumber, int pageSize)
        {
            return await _context.students.Skip((PageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public List<GetAllStudents> Search(string Name)
        {
            return _context.students.Where(i => i.FullName.Contains(Name)).Select(i => new GetAllStudents
            {
                FullName = i.FullName,
                DateOfBirth = i.DateOfBirth,
                Email = i.Email,
                Gender = i.Gender,
                PhoneNumber = i.PhoneNumber,
            }).ToList();
        }
    }
}
