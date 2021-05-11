﻿// <auto-generated />
using System;
using MVCAssignmentPerson.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCAssignmentPerson.Migrations
{
    [DbContext(typeof(PeopleDbContext))]
    [Migration("20210511084516_Personfix")]
    partial class Personfix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cityis");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InCityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("InCityId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguages");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.City", b =>
                {
                    b.HasOne("MVCAssignmentPerson.Models.Data.Country", "Country")
                        .WithMany("CityInCountry")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.Person", b =>
                {
                    b.HasOne("MVCAssignmentPerson.Models.Data.City", "InCity")
                        .WithMany("PersonsInCity")
                        .HasForeignKey("InCityId");

                    b.Navigation("InCity");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.PersonLanguage", b =>
                {
                    b.HasOne("MVCAssignmentPerson.Models.Data.Language", "Language")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCAssignmentPerson.Models.Data.Person", "Person")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.City", b =>
                {
                    b.Navigation("PersonsInCity");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.Country", b =>
                {
                    b.Navigation("CityInCountry");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.Language", b =>
                {
                    b.Navigation("PersonLanguages");
                });

            modelBuilder.Entity("MVCAssignmentPerson.Models.Data.Person", b =>
                {
                    b.Navigation("PersonLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}