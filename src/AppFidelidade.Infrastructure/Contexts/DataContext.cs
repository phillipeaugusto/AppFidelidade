using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AppFidelidade.Domain.Entities;
using AppFidelidade.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AppFidelidade.Infrastructure.Contexts;

public class DataContext : DbContext
{
    [ExcludeFromCodeCoverage]
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
            
        modelBuilder
            .ApplyConfiguration(new CityMapping())
            .ApplyConfiguration(new ClientMapping())
            .ApplyConfiguration(new CountryMapping())
            .ApplyConfiguration(new PartnerMapping())
            .ApplyConfiguration(new CardMapping());

        modelBuilder.Entity<Country>().HasData(new Country(Guid.Parse("f97def59-a619-4a97-adb3-f38852a6ad45"),"Brasil"));
        modelBuilder.Entity<City>().HasData(new List<City>
        {
            new City(Guid.Parse("f97def59-a619-4a97-adb3-f38852a6ad45"), "Goiania"),
            new City(Guid.Parse("f97def59-a619-4a97-adb3-f38852a6ad45"), "Altamira")
        });
    }

    public DbSet<City> City { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Partner> Partner { get; set; }
    public DbSet<Card> Card { get; set; }
}