using School_ManagementDemo.AllDTOs.CourseDTOs;
using School_ManagementDemo.Genarics;
using School_ManagementDemo.Models;

namespace School_ManagementDemo.AllCustoms.CourseCustom
{
    public interface ICourseRepo : IGenaricRepo<Course>
    {
        Task<List<AllDTOs.CourseDTOs.GetAllCoursees>> search(string name);
        Task<List<getallcoursesss>> Filter(int Id, int hours);
    }
}
