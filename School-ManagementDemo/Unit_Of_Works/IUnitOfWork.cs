using School_ManagementDemo.AllCustoms.StudentCustom;
using School_ManagementDemo.Genarics;
using School_ManagementDemo.Models;

namespace School_ManagementDemo.Unit_Of_Works
{
    public interface IUnitOfWork
    {
        IGenaricRepo<Teacher> teacher {  get; }
        IStudentRepo student {  get; }
        IGenaricRepo<StudentProfile> studentProfile {  get; }
        IGenaricRepo<Course> course {  get; }
        IGenaricRepo<Enrollment> Enrollment {  get; }

       Task<int> Save();

    }
}
