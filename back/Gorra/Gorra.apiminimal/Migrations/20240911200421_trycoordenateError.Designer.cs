﻿// <auto-generated />
using System;
using Gorra.apiminimal.Infrestructure.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gorra.apiminimal.Migrations
{
    [DbContext(typeof(GorraDbContext))]
    [Migration("20240911200421_trycoordenateError")]
    partial class trycoordenateError
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gorra.apiminimal.Domain.Entities.Ciudadano", b =>
                {
                    b.Property<int>("CitizenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CitizenId"));

                    b.Property<string>("CitizenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CitizenPass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CitizenId");

                    b.ToTable("Ciudadanos");
                });

            modelBuilder.Entity("Gorra.apiminimal.Domain.Entities.Denuncia", b =>
                {
                    b.Property<int>("IdDenuncia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDenuncia"));

                    b.Property<string>("Coordenadas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DenunciaDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCitizen")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdDenuncia");

                    b.HasIndex("IdCitizen");

                    b.ToTable("Denuncias");
                });

            modelBuilder.Entity("Gorra.apiminimal.Domain.Entities.Denuncia", b =>
                {
                    b.HasOne("Gorra.apiminimal.Domain.Entities.Ciudadano", null)
                        .WithMany("DeclaredDenuncia")
                        .HasForeignKey("IdCitizen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gorra.apiminimal.Domain.Entities.Ciudadano", b =>
                {
                    b.Navigation("DeclaredDenuncia");
                });
#pragma warning restore 612, 618
        }
    }
}
