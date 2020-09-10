﻿// <auto-generated />
using System;
using DataAcces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAcces.Migrations
{
    [DbContext(typeof(MysqlDbContext))]
    [Migration("20200825181457_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.MS_Competence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Kompetence")
                        .HasColumnType("text");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MS_Competence");
                });

            modelBuilder.Entity("Model.MS_Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("MS_PortfolioId")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MS_PortfolioId");

                    b.ToTable("MS_Picture");
                });

            modelBuilder.Entity("Model.MS_Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Beskrivelse")
                        .HasColumnType("text");

                    b.Property<int?>("FrontFotoId")
                        .HasColumnType("int");

                    b.Property<string>("Navn")
                        .HasColumnType("text");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("FrontFotoId");

                    b.ToTable("MS_Portfolio");
                });

            modelBuilder.Entity("Model.MS_Picture", b =>
                {
                    b.HasOne("Model.MS_Portfolio", null)
                        .WithMany("PhotoLinks")
                        .HasForeignKey("MS_PortfolioId");
                });

            modelBuilder.Entity("Model.MS_Portfolio", b =>
                {
                    b.HasOne("Model.MS_Picture", "FrontFoto")
                        .WithMany()
                        .HasForeignKey("FrontFotoId");
                });
#pragma warning restore 612, 618
        }
    }
}