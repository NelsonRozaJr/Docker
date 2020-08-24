using Microsoft.EntityFrameworkCore;
using NetCoreStudent.Models;

namespace NetCoreStudent.Context
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}