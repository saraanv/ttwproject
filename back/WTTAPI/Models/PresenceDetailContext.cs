using Microsoft.EntityFrameworkCore;

namespace WTTAPI.Models
{
    public class PresenceDetailContext : DbContext
    {
        public PresenceDetailContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PresenceDetail> PresenceDetails { get; set; }
        public DbSet<ProjectDetail> ProjectDetails { get; set; }

    }
}
