namespace SchoolManagementSys.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
}
