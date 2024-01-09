namespace WebAPI_Tutorial_2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public Teacher Teacher { get; set; } = null!;
    }
}
