using Microsoft.EntityFrameworkCore;
using StudentListEF.Models;

namespace StudentListEF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<StudentList> StudentList { get; set; }
    }
}
