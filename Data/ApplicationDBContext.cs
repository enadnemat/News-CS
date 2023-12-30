using Microsoft.EntityFrameworkCore;
using News.Models;

namespace News.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option) : base(option)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
