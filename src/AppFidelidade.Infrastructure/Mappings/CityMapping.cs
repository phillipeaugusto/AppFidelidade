using System.Diagnostics.CodeAnalysis;
using AppFidelidade.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFidelidade.Infrastructure.Mappings
{    
    [ExcludeFromCodeCoverage]
    public class CityMapping: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(key => new {key.Id});

            builder.Property(prop => prop.Id)
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(prop => prop.CountryId)
                .HasColumnType("char(36)")
                .IsRequired();
            
            builder.HasOne(prop => prop.Country)
                .WithMany(x => x.City)
                .HasForeignKey(prop => prop.CountryId);

            builder.Property(prop => prop.Status)
                .HasColumnType("char(1)")
                .IsRequired();
            
            builder.Property(prop => prop.Description)
                .HasColumnType("varchar(80)")
                .IsRequired();
            
            builder.Property(prop => prop.DateChange)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(prop => prop.DateCreation)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}