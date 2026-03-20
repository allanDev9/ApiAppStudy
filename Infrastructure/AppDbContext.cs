using ApiAppStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAppStudy.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Define tus DbSets (tablas)
        public DbSet<Activity> Activites { get; set; }

    }
}
