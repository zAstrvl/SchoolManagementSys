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
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    Name = "Ali",
                    Surname = "Demir",
                    DateOfBirth = new DateTime(1985, 3, 15),
                    Subject = "Mathematics",
                    Email = "fsadfasfas@aasdfasddas.cascas",
                    PhoneNumber = "123456789013234",
                    Graduated = "Ankara University"
                },
                new Teacher
                {
                    Id = 2,
                    Name = "Veli",
                    Surname = "Demirci",
                    DateOfBirth = new DateTime(1984, 1, 24),
                    Subject = "Physics",
                    Email = "fadfas@aasrewdff.aascas",
                    PhoneNumber = "123451308224",
                    Graduated = "Istanbul University"
                }
                );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        }
}
