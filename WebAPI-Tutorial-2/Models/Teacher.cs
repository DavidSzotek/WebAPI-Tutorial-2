using System.ComponentModel.DataAnnotations;

namespace WebAPI_Tutorial_2.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        public List<Course> Courses { get; set; } = null!;

    }
}
