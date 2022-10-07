using Microsoft.EntityFrameworkCore;
using StudentData.Models;

namespace StudentData.Data
{
    public class ApplicationDBContext:DbContext
    {
        public  ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) 
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
