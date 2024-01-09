namespace WebAPI_Tutorial_2.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Place { get; set; } = null!;
    }
}
