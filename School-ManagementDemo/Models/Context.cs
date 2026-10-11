using Microsoft.EntityFrameworkCore;

namespace School_ManagementDemo.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt):base(opt) { }

        public DbSet<Student> students { get; set; }
        public DbSet<StudentProfile> studentProfiles { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Teacher> teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany(o => o.enrollments).WithOne(o => o.Student).HasForeignKey(o => o.StudentId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Course>().HasMany(o => o.enrollments).WithOne(o => o.Course).HasForeignKey(o => o.CourseId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Student>().HasOne(o => o.StudentProfile).WithOne(o => o.Student).HasForeignKey<StudentProfile>(o => o.StudentId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Teacher>().HasMany(i => i.courses).WithOne(o => o.Teacher).HasForeignKey(o => o.TeacherId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>().HasIndex(m => new { m.StudentId, m.CourseId }).IsUnique();


        }

    }
}
