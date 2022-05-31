﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReloadingBackend;

#nullable disable

namespace ReloadingBackend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220520074045_range_test")]
    partial class range_test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("ReloadingBackend.Models.Bullet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bullets");
                });

            modelBuilder.Entity("ReloadingBackend.Models.Powder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Powders");
                });

            modelBuilder.Entity("ReloadingBackend.Models.Primer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Primers");
                });

            modelBuilder.Entity("ReloadingBackend.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BulletId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PowderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrimerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BulletId");

                    b.HasIndex("PowderId");

                    b.HasIndex("PrimerId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("ReloadingBackend.Models.RoundTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Velocity")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("RoundId")
                        .IsUnique();

                    b.ToTable("RoundTest");
                });

            modelBuilder.Entity("ReloadingBackend.Models.Round", b =>
                {
                    b.HasOne("ReloadingBackend.Models.Bullet", "Bullet")
                        .WithMany("Rounds")
                        .HasForeignKey("BulletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReloadingBackend.Models.Powder", "Powder")
                        .WithMany("Rounds")
                        .HasForeignKey("PowderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReloadingBackend.Models.Primer", "Primer")
                        .WithMany("Rounds")
                        .HasForeignKey("PrimerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bullet");

                    b.Navigation("Powder");

                    b.Navigation("Primer");
                });

            modelBuilder.Entity("ReloadingBackend.Models.RoundTest", b =>
                {
                    b.HasOne("ReloadingBackend.Models.Round", "Round")
                        .WithOne("RoundTest")
                        .HasForeignKey("ReloadingBackend.Models.RoundTest", "RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Round");
                });

            modelBuilder.Entity("ReloadingBackend.Models.Bullet", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("ReloadingBackend.Models.Powder", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("ReloadingBackend.Models.Primer", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("ReloadingBackend.Models.Round", b =>
                {
                    b.Navigation("RoundTest")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}