using Microsoft.EntityFrameworkCore;
using School_ManagementDemo.AllDTOs.CourseDTOs;
using School_ManagementDemo.Generics;
using School_ManagementDemo.Models;

namespace School_ManagementDemo.AllCustoms.CourseCustom
{
    public class CourseRepo  : GenericRepo<Course> , ICourseRepo
    {
        private readonly Context _context;
        public CourseRepo(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<getallcoursesss>> Filter(int Id, int hours)
        {
            return await _context.courses
                .Where(c => c.TeacherId == Id && c.CreditHours <= hours).Select(o => new getallcoursesss
            {
                Teacher = new Teacher
                {
                    Email = o.Teacher.Email,
                    FullName = o.Teacher.FullName,
                    HireDate = o.Teacher.HireDate,
                    PhoneNumber = o.Teacher.PhoneNumber,
                    Id = o.Teacher.Id,
                },
                CreditHours = o.CreditHours,
                Id = o.Id,
                Title = o.Title,

            }).ToListAsync();
        }

        public async Task<List<GetAllCoursees>> search(string name)
        {
            return await _context.courses.Where(i => i.Title.Contains(name)).Select(i => new GetAllCoursees
            {
                Title = i.Title,
                Id = i.Id,
                CreditHours = i.CreditHours,
            }).ToListAsync();
        }
    }
}
