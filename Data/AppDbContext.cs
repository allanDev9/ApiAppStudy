using ApiAppStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAppStudy.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Activity> Activities => Set<Activity>();
}
