using Microsoft.EntityFrameworkCore;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Eren",
                    Surname = "Arslan",
                    DateOfBirth = new DateTime(2004, 5, 31)
                },
                new Student
                {
                    Id = 2,
                    Name = "Miraç Can",
                    Surname = "Yüksel",
                    DateOfBirth = new DateTime(2000, 10, 24)
                },
                new Student
                {
                    Id = 3,
                    Name = "Kürşat",
                    Surname = "Özel",
                    DateOfBirth = new DateTime(1981, 6, 26)
                },
                new Student
                {
                    Id = 4,
                    Name = "Ömer Can",
                    Surname = "Yiğit",
                    DateOfBirth = new DateTime(1993, 4, 27)
                }
                );
        }
        public DbSet<Student> Students { get; set; }
    }
}
