using DbFileApi.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFileApi.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<UserProfile> Users { get; set; }
    }
}
