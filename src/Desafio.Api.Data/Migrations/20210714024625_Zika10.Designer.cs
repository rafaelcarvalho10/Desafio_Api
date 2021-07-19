﻿// <auto-generated />
using System;
using Desafio.Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Desafio.Api.Data.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    [Migration("20210714024625_Zika10")]
    partial class Zika10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Desafio.Api.Domain.Entities.Escola", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Escola");
                });

            modelBuilder.Entity("Desafio.Api.Domain.Entities.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<Guid>("EscolaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EscolaId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("Desafio.Api.Domain.Entities.Turma", b =>
                {
                    b.HasOne("Desafio.Api.Domain.Entities.Escola", "Escola")
                        .WithMany()
                        .HasForeignKey("EscolaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Escola");
                });
#pragma warning restore 612, 618
        }
    }
}
