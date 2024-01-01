﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebProje.Models;

#nullable disable

namespace WebProje.Migrations
{
    [DbContext(typeof(DbContextUcus))]
    partial class DbContextUcusModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebProje.Models.Havalemani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("HavalemanininAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SehirId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SehirId");

                    b.ToTable("havalemaniler");
                });

            modelBuilder.Entity("WebProje.Models.Koltuk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.Property<int>("UcakId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UcakId");

                    b.ToTable("Koltuklar");
                });

            modelBuilder.Entity("WebProje.Models.Login", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("WebProje.Models.Rezervasyon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("KalkisSehirId")
                        .HasColumnType("integer");

                    b.Property<int>("KoltukNumarasi")
                        .HasColumnType("integer");

                    b.Property<int>("SYolID")
                        .HasColumnType("integer");

                    b.Property<int>("Ucak")
                        .HasColumnType("integer");

                    b.Property<int>("VarisSehirId")
                        .HasColumnType("integer");

                    b.Property<int>("YolcuID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SYolID");

                    b.HasIndex("Ucak");

                    b.HasIndex("YolcuID");

                    b.ToTable("Rezervasyonlar");
                });

            modelBuilder.Entity("WebProje.Models.Sehir", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("sehirler");
                });

            modelBuilder.Entity("WebProje.Models.Sirket", b =>
                {
                    b.Property<int>("SirketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SirketId"));

                    b.Property<string>("SirketName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SirketId");

                    b.ToTable("sirketler");
                });

            modelBuilder.Entity("WebProje.Models.Ucak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("KoltukSayisi")
                        .HasColumnType("integer");

                    b.Property<int>("sirketsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("sirketsId");

                    b.ToTable("Ucaklar");
                });

            modelBuilder.Entity("WebProje.Models.YeniKullanci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SoyAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("adminmi")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("yeniKullancis");
                });

            modelBuilder.Entity("WebProje.Models.Yol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Fiyat")
                        .HasColumnType("integer");

                    b.Property<int>("KalkisSehirId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("KalkisZaman")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UCAKID")
                        .HasColumnType("integer");

                    b.Property<int>("VarisSehirId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("VarisZaman")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("KalkisSehirId");

                    b.HasIndex("UCAKID");

                    b.HasIndex("VarisSehirId");

                    b.ToTable("Yollar");
                });

            modelBuilder.Entity("WebProje.Models.Havalemani", b =>
                {
                    b.HasOne("WebProje.Models.Sehir", "Sehir")
                        .WithMany("Havalemaniler")
                        .HasForeignKey("SehirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sehir");
                });

            modelBuilder.Entity("WebProje.Models.Koltuk", b =>
                {
                    b.HasOne("WebProje.Models.Ucak", "ucaks1")
                        .WithMany("Koltuklar")
                        .HasForeignKey("UcakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ucaks1");
                });

            modelBuilder.Entity("WebProje.Models.Rezervasyon", b =>
                {
                    b.HasOne("WebProje.Models.Yol", "Yol")
                        .WithMany("Rezervasyonlar")
                        .HasForeignKey("SYolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProje.Models.Ucak", "UcakNavigation")
                        .WithMany("rezervasyonlar")
                        .HasForeignKey("Ucak")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProje.Models.YeniKullanci", "Yolcu")
                        .WithMany("rezervasyonlar")
                        .HasForeignKey("YolcuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UcakNavigation");

                    b.Navigation("Yol");

                    b.Navigation("Yolcu");
                });

            modelBuilder.Entity("WebProje.Models.Ucak", b =>
                {
                    b.HasOne("WebProje.Models.Sirket", "sirkets")
                        .WithMany("ucaklar")
                        .HasForeignKey("sirketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sirkets");
                });

            modelBuilder.Entity("WebProje.Models.Yol", b =>
                {
                    b.HasOne("WebProje.Models.Sehir", "KalkisSehir")
                        .WithMany("KalkisYollar")
                        .HasForeignKey("KalkisSehirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProje.Models.Ucak", "UCAK")
                        .WithMany("Yollar")
                        .HasForeignKey("UCAKID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProje.Models.Sehir", "VarisSehir")
                        .WithMany("VarisYollar")
                        .HasForeignKey("VarisSehirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KalkisSehir");

                    b.Navigation("UCAK");

                    b.Navigation("VarisSehir");
                });

            modelBuilder.Entity("WebProje.Models.Sehir", b =>
                {
                    b.Navigation("Havalemaniler");

                    b.Navigation("KalkisYollar");

                    b.Navigation("VarisYollar");
                });

            modelBuilder.Entity("WebProje.Models.Sirket", b =>
                {
                    b.Navigation("ucaklar");
                });

            modelBuilder.Entity("WebProje.Models.Ucak", b =>
                {
                    b.Navigation("Koltuklar");

                    b.Navigation("Yollar");

                    b.Navigation("rezervasyonlar");
                });

            modelBuilder.Entity("WebProje.Models.YeniKullanci", b =>
                {
                    b.Navigation("rezervasyonlar");
                });

            modelBuilder.Entity("WebProje.Models.Yol", b =>
                {
                    b.Navigation("Rezervasyonlar");
                });
#pragma warning restore 612, 618
        }
    }
}
