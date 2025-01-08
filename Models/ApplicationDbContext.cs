using Microsoft.EntityFrameworkCore;

namespace PlacementTracker.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PlacementActivity> PlacementActivities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
