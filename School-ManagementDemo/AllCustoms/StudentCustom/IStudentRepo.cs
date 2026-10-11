using School_ManagementDemo.Genarics;
using School_ManagementDemo.Models;

namespace School_ManagementDemo.AllCustoms.StudentCustom
{
    public interface IStudentRepo : IGenaricRepo<Student>
    {
        List<AllDTOs.StudentDTOs.GetAllStudents> Search(string Name);
        List<AllDTOs.StudentDTOs.GetAllStudents> Filter(string Gender);
        Task<List<Student>> pagination(int PageNumber, int pageSize);
    }
}
