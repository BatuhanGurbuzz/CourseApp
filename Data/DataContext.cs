using Microsoft.EntityFrameworkCore;

namespace CourseApp.Data
{
    
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<CourseRegister> CourseRegisters { get; set; }
    }
}