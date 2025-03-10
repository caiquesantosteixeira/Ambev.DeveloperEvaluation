using Ambev.DeveloperEvaluation.Domain.Entities;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<BranchStore> BranchStore { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Sale> Sale { get; set; }
    public DbSet<SaleItem> SaleItem { get; set; }
    public DbSet<Store> Store { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
        Triggers<Sale>.Inserting += entry =>
        {
            Console.WriteLine($"Inserting Sale: {entry.Entity.Id}");
        };

        Triggers<Sale>.Updating += entry =>
        {
            Console.WriteLine($"Updating Sale: {entry.Entity.Id}");
        };

        Triggers<Sale>.Updating += entry =>
        {
            if (entry.Entity.Canceled) 
            {
                Console.WriteLine($"Sale with id:{entry.Entity.Id} was canceled");
            }
        };

        Triggers<SaleItem>.Updating += entry =>
        {
            if (entry.Entity.Canceled)
            {
                Console.WriteLine($"Sale item with id:{entry.Entity.Id} was canceled");
            }
        };
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
               connectionString,
               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
        );

        return new DefaultContext(builder.Options);
    }
}