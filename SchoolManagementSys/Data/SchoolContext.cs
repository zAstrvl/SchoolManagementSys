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
        }

        // Sets for the database tables
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<MailData> MailData { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
