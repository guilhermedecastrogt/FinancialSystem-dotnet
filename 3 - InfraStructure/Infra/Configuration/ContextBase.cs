using Entities._4___Entities.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities._3___InfraStructure.Infra.Configuration;

public class ContextBase : IdentityDbContext<ApplicationUser>
{
    public ContextBase(DbContextOptions options) : base(options)
    {
    }

    public DbSet<FinancialSystem> FinancialSystems { get; set; }
    public DbSet<FinancialSystemUser> FinancialSystemUsers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Expenses> Expenses { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<ApplicationUser>()
            .ToTable("USR_USER")
            .HasKey(t => t.Id);
        
        base.OnModelCreating(builder);
    }
    
    public string GetConnectionString()
    {
        return "Data Source=DESKTOP-2Q3VJ8M;Initial Catalog=FinancialSystem;Integrated Security=False";
    }
    
}