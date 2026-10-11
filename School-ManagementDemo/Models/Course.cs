using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_ManagementDemo.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required , MinLength(3) , MaxLength(100)]
        public string Title  { get; set; }
        [Required , Range(1 , 6)]
        public int CreditHours { get; set; }

        public Teacher Teacher { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }

        public ICollection<Enrollment> enrollments { get; set; } = new List<Enrollment>();
    }
}
