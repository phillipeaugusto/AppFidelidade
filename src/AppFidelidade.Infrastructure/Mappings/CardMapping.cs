using System.Diagnostics.CodeAnalysis;
using AppFidelidade.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFidelidade.Infrastructure.Mappings
{
    [ExcludeFromCodeCoverage]
    public class CardMapping: IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(key => new {key.Id});

            builder.Property(prop => prop.Id)
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(prop => prop.CardNumber)
                .HasColumnType("varchar(16)")
                .IsRequired();
            
            builder.HasOne(prop => prop.Client)
                .WithMany(x => x.Card)
                .HasForeignKey(prop => prop.ClientId);

            builder.Property(prop => prop.ClientId)
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(prop => prop.Status)
                .HasColumnType("char(1)")
                .IsRequired();
            
            builder.Property(prop => prop.ExpirationMonth)
                .HasColumnType("int")
                .IsRequired();
            
            builder.Property(prop => prop.ExpirationYear)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(prop => prop.SecurityCode)
                .HasColumnType("int")
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