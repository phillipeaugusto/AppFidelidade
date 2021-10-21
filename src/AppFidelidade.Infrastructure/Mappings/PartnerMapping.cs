using System.Diagnostics.CodeAnalysis;
using AppFidelidade.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFidelidade.Infrastructure.Mappings
{
    public class PartnerMapping: IEntityTypeConfiguration<Partner>
    {
        [ExcludeFromCodeCoverage]
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.HasKey(key => new {key.Id});

            builder.Property(prop => prop.Id)
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(prop => prop.CityId)
                .HasColumnType("char(36)")
                .IsRequired();
            
            builder.HasOne(prop => prop.City)
                .WithMany(x => x.Partner)
                .HasForeignKey(prop => prop.CityId);

            builder.Property(prop => prop.Status)
                .HasColumnType("char(1)")
                .IsRequired();
            
            builder.Property(prop => prop.CnpjCpf)
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(prop => prop.CorporateName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(prop => prop.FantasyName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(prop => prop.PersonType)
                .HasColumnType("varchar(1)")
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