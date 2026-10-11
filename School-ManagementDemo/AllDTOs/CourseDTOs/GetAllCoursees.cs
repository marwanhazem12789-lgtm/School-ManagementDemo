using System.ComponentModel.DataAnnotations;

namespace School_ManagementDemo.AllDTOs.CourseDTOs
{
    public class GetAllCoursees
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string Title { get; set; }
        [Required, Range(1, 6)]
        public int CreditHours { get; set; }
    }
}
