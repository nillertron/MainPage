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
    [Migration("20200906093210_polymorf")]
    partial class polymorf
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

            modelBuilder.Entity("Model.MS_Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Headline")
                        .HasColumnType("text");

                    b.Property<DateTime>("MessageSent")
                        .HasColumnType("datetime");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<string>("SenderEmail")
                        .HasColumnType("text");

                    b.Property<string>("SenderName")
                        .HasColumnType("text");

                    b.Property<string>("SenderPhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MS_Messages");

                    b.HasDiscriminator<string>("Discriminator").HasValue("MS_Message");
                });

            modelBuilder.Entity("Model.MS_Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("FrontFoto")
                        .HasColumnType("bit");

                    b.Property<int>("MS_PortfolioId")
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

                    b.Property<string>("Navn")
                        .HasColumnType("text");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("MS_Portfolio");
                });

            modelBuilder.Entity("Model.MS_User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MS_User");
                });

            modelBuilder.Entity("Model.MS_FreeLanceMessage", b =>
                {
                    b.HasBaseType("Model.MS_Message");

                    b.Property<double>("Budget")
                        .HasColumnType("double");

                    b.Property<string>("ClientLocation")
                        .HasColumnType("text");

                    b.Property<string>("Currency")
                        .HasColumnType("text");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime");

                    b.Property<string>("FreelanceJobType")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("MS_FreeLanceMessage");
                });

            modelBuilder.Entity("Model.MS_JobMessage", b =>
                {
                    b.HasBaseType("Model.MS_Message");

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("text");

                    b.Property<string>("CompanyCity")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("MS_JobMessage");
                });

            modelBuilder.Entity("Model.MS_Picture", b =>
                {
                    b.HasOne("Model.MS_Portfolio", null)
                        .WithMany("PhotoLinks")
                        .HasForeignKey("MS_PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
