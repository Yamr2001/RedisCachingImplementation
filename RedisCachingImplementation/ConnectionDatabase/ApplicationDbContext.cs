using Microsoft.EntityFrameworkCore;
using RedisCachingImplementation.Entities;

namespace RedisCachingImplementation.ConnectionDatabase
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Cars> Cars { get; set; }
    }
}
