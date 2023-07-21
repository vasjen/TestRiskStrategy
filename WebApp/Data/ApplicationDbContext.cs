
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _config;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration config)
        : base(options)
    {
    }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Table");
        
    }

    protected override void OnModelCreating (ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
    }
}
