﻿using System.Diagnostics.CodeAnalysis;
using AppFidelidade.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFidelidade.Infrastructure.Mappings
{
    [ExcludeFromCodeCoverage]
    public class ClientMapping: IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(key => new {key.Id});
            
            builder.Property(prop => prop.Id)
                .HasColumnType("char(36)")
                .IsRequired();

            builder.Property(prop => prop.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(prop => prop.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(prop => prop.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(prop => prop.Number)
                .HasColumnType("varchar(30)")
                .IsRequired();
            
            builder.Property(prop => prop.Role)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(prop => prop.CityId)
                .HasColumnType("char(36)")
                .IsRequired();
          
            builder.HasOne(prop => prop.City)
                .WithMany(x => x.Client)
                .HasForeignKey(prop => prop.CityId);

            builder.Property(prop => prop.PassWord)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(prop => prop.Status)
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