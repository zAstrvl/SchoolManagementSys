namespace SchoolManagementSys.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = null!;
        public UserType UserType { get; set; }
    }
}
