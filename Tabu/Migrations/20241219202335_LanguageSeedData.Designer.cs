﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tabu.DAL;

#nullable disable

namespace Tabu.Migrations
{
    [DbContext(typeof(TabuDbContext))]
    [Migration("20241219202335_LanguageSeedData")]
    partial class LanguageSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tabu.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BannedWordCount")
                        .HasColumnType("int");

                    b.Property<int>("FailCount")
                        .HasColumnType("int");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(2)")
                        .HasDefaultValue("Az");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("SkipCount")
                        .HasColumnType("int");

                    b.Property<int>("SuccessAsnwer")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<int>("WrongAnswer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageCode");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Tabu.Entities.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Code");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Code = "Az",
                            Icon = "https://upload.wikimedia.org/wikipedia/commons/3/3d/AZ-Azerbaijan-Flag-icon.png",
                            Name = "Azerbaijan"
                        },
                        new
                        {
                            Code = "En",
                            Icon = "https://cdn-icons-png.freepik.com/256/6737/6737832.png?semt=ais_hybrid",
                            Name = "English"
                        });
                });

            modelBuilder.Entity("Tabu.Entities.Game", b =>
                {
                    b.HasOne("Tabu.Entities.Language", "Language")
                        .WithMany("Games")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Tabu.Entities.Language", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
