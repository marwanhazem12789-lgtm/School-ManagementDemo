using Microsoft.Identity.Client;
using School_ManagementDemo.AllCustoms.StudentCustom;
using School_ManagementDemo.Genarics;
using School_ManagementDemo.Models;

namespace School_ManagementDemo.Unit_Of_Works
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

       
        public IGenaricRepo<Teacher> teacher { get; }

        public IStudentRepo student { get; }

        public IGenaricRepo<StudentProfile> studentProfile { get;}

        public IGenaricRepo<Course> course { get; }

        public IGenaricRepo<Enrollment> Enrollment { get; }

        public UnitOfWork(Context context , IStudentRepo s , IGenaricRepo<StudentProfile> sp , IGenaricRepo<Teacher> t , IGenaricRepo<Course> cc , IGenaricRepo<Enrollment> e)
        {
            _context = context;
            student = s;
            studentProfile = sp;
            Enrollment = e;
            course = cc;
            teacher = t;

        }


        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
