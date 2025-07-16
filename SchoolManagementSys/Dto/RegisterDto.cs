using SchoolManagementSys.Models;

namespace SchoolManagementSys.Dto
{
    public class RegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Agreed { get; set; }
        public UserType UserType { get; set; }
    }
}
