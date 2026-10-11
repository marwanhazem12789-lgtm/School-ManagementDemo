using School_ManagementDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace School_ManagementDemo.AllDTOs.TeacherDTOs
{
    public class CreateTeacher
    {
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]

        public string Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]

        public DateTime HireDate { get; set; }
    }
}
