using System.Diagnostics.CodeAnalysis;
using AppFidelidade.Core.Entities;
using AppFidelidade.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AppFidelidade.Infrastructure.Contexts
{
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
        }

        public DbSet<City> City { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<Card> Card { get; set; }
    }
}