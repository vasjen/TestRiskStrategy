
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _config;
    public DbSet<Employee> Employees {get;set;}
    public DbSet<Company> Companies {get;set;}
    public DbSet<Note> Notes {get;set;}
    public DbSet<History> Histories {get;set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    
    {
        
        
    }

    protected override void OnModelCreating (ModelBuilder builder)
    {
       
        
    }
}
