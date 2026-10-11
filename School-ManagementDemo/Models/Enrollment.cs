using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_ManagementDemo.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Required, Range(0, 100)]
        public decimal? Grade { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
