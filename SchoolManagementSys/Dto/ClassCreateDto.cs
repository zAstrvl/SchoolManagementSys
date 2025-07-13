namespace SchoolManagementSys.Dto
{
    public class ClassCreateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TeacherId { get; set; }
        public List<int> StudentIds { get; set; } = new(); 
    }
}
