using System.ComponentModel.DataAnnotations;

namespace School_ManagementDemo.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(200)]
        public string Address { get; set; }
        [Required , Phone]
        public string ParentPhone { get; set; }
        [Required, Phone]
        public string EmergencyContact { get; set; }


        public Student Student  { get; set; }
        public int StudentId { get; set; }
    }
}
