﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YoreselSozluk.DataAccess.Concrete;

namespace YoreselSozluk.DataAccess.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("YoreselSozluk.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("DownCount")
                        .HasColumnType("int");

                    b.Property<int>("HeadingId")
                        .HasColumnType("int");

                    b.Property<int>("UpCount")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.Heading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("Headings");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.HeadingCity", b =>
                {
                    b.Property<int>("HeadingId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CityId1")
                        .HasColumnType("int");

                    b.HasKey("HeadingId", "CityId");

                    b.HasIndex("CityId");

                    b.HasIndex("CityId1");

                    b.ToTable("HeadingCity");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int?>("HeadingId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RefreshTokenExpireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Roles")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HeadingId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.Heading", b =>
                {
                    b.HasOne("YoreselSozluk.Entities.City", "City")
                        .WithMany("Headings")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoreselSozluk.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.HeadingCity", b =>
                {
                    b.HasOne("YoreselSozluk.Entities.Heading", "Heading")
                        .WithMany("HeadingCities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoreselSozluk.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Heading");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.Region", b =>
                {
                    b.HasOne("YoreselSozluk.Entities.City", null)
                        .WithMany("Regions")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.User", b =>
                {
                    b.HasOne("YoreselSozluk.Entities.Heading", null)
                        .WithMany("Users")
                        .HasForeignKey("HeadingId");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.City", b =>
                {
                    b.Navigation("Headings");

                    b.Navigation("Regions");
                });

            modelBuilder.Entity("YoreselSozluk.Entities.Heading", b =>
                {
                    b.Navigation("HeadingCities");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
