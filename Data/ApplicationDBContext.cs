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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id=1 , Name="Sports"   , Description ="fgsdfg" },
                new Category {Id=2 , Name="History"  , Description ="sfgdfghsdg" },
                new Category {Id=3 , Name="Politics" , Description ="fgokjspodifghjiodsf" },
                new Category {Id=4 , Name="Whatever" , Description = "tgjisduohgrshu" }
                );
        }
    }
}
