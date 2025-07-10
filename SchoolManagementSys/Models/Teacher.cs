namespace SchoolManagementSys.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Subject { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Graduated { get; set; }
        public ICollection<Class>? Classes { get; set; }
    }
}
