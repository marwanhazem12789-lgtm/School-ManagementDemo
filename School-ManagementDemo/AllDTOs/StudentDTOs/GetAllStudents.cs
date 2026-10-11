using System.ComponentModel.DataAnnotations;

namespace School_ManagementDemo.AllDTOs.StudentDTOs
{
    public class GetAllStudents
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]

        public string Email { get; set; }
        [Required, Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }



    }
}
