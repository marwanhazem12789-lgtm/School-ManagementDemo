using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace School_ManagementDemo.Models
{
    [Index(nameof(Email), IsUnique =true)]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(3), MaxLength(100)]
        public string FullName { get; set; }

        [Required,  EmailAddress]

        public string Email { get; set; }
        [ Phone]
        public string? PhoneNumber { get; set; }
        [Required]

        public DateTime HireDate {  get; set; } 
        public ICollection<Course> courses { get; set; } = new List<Course>();
    }
}
