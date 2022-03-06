using System.Diagnostics.CodeAnalysis;
using AppFidelidade.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFidelidade.Infrastructure.Mappings
{
    [ExcludeFromCodeCoverage]
    public class CountryMapping: IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(key => new {key.Id});

            builder.Property(prop => prop.Id)
                .HasColumnType("char(36)")
                .IsRequired();
            
            builder.Property(prop => prop.Status)
                .HasColumnType("char(1)")
                .IsRequired();
            
            builder.Property(prop => prop.Description)
                .HasColumnType("varchar(36)")
                .IsRequired();
            
            builder.Property(prop => prop.DateChange)
                .HasColumnType("timestamp(0)")
                .IsRequired();

            builder.Property(prop => prop.DateCreation)
                .HasColumnType("timestamp(0)")
                .IsRequired();

        }
    }
}