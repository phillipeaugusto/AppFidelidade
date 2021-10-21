﻿// <auto-generated />
using System;
using AppFidelidade.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppFidelidade.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210827142714_01")]
    partial class _01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("AppFidelidade.Core.Entities.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime");

                    b.Property<int>("ExpirationMonth")
                        .HasColumnType("int");

                    b.Property<int>("ExpirationYear")
                        .HasColumnType("int");

                    b.Property<int>("SecurityCode")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.Partner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("char(36)");

                    b.Property<string>("CnpjCpf")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime");

                    b.Property<string>("FantasyName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PersonType")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Partner");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.Card", b =>
                {
                    b.HasOne("AppFidelidade.Core.Entities.Client", "Client")
                        .WithMany("Card")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.City", b =>
                {
                    b.HasOne("AppFidelidade.Core.Entities.Country", "Country")
                        .WithMany("City")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.Client", b =>
                {
                    b.HasOne("AppFidelidade.Core.Entities.City", "City")
                        .WithMany("Client")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.Partner", b =>
                {
                    b.HasOne("AppFidelidade.Core.Entities.City", "City")
                        .WithMany("Partner")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.City", b =>
                {
                    b.Navigation("Client");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.Client", b =>
                {
                    b.Navigation("Card");
                });

            modelBuilder.Entity("AppFidelidade.Core.Entities.Country", b =>
                {
                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}