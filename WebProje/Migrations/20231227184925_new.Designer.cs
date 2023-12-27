﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebProje.Models;

#nullable disable

namespace WebProje.Migrations
{
    [DbContext(typeof(DbContextUcus))]
    [Migration("20231227184925_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Id1")
                        .HasColumnType("integer");

                    b.Property<int>("KoltukNumarasi")
                        .HasColumnType("integer");

                    b.Property<int>("SYolID")
                        .HasColumnType("integer");

                    b.Property<int>("Ucak")
                        .HasColumnType("integer");

                    b.Property<int>("YolcuID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id1");

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

            modelBuilder.Entity("WebProje.Models.Ucak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("KoltukSayisi")
                        .HasColumnType("integer");

                    b.HasKey("Id");

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

                    b.HasKey("Id");

                    b.ToTable("yeniKullancis");
                });

            modelBuilder.Entity("WebProje.Models.Yol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("KalkisSehir")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("KalkisZaman")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("VarisSehri")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("VarisZaman")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Yollar");
                });

            modelBuilder.Entity("WebProje.Models.Havalemani", b =>
                {
                    b.HasOne("WebProje.Models.Sehir", "sehir")
                        .WithMany("havalemaniler")
                        .HasForeignKey("SehirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sehir");
                });

            modelBuilder.Entity("WebProje.Models.Rezervasyon", b =>
                {
                    b.HasOne("WebProje.Models.Yol", "ID")
                        .WithMany("rezervasyonlar")
                        .HasForeignKey("Id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProje.Models.Ucak", "ucak")
                        .WithMany("rezervasyonlar")
                        .HasForeignKey("Ucak")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProje.Models.YeniKullanci", "YolcuId")
                        .WithMany("rezervasyonlar")
                        .HasForeignKey("YolcuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ID");

                    b.Navigation("YolcuId");

                    b.Navigation("ucak");
                });

            modelBuilder.Entity("WebProje.Models.Sehir", b =>
                {
                    b.Navigation("havalemaniler");
                });

            modelBuilder.Entity("WebProje.Models.Ucak", b =>
                {
                    b.Navigation("rezervasyonlar");
                });

            modelBuilder.Entity("WebProje.Models.YeniKullanci", b =>
                {
                    b.Navigation("rezervasyonlar");
                });

            modelBuilder.Entity("WebProje.Models.Yol", b =>
                {
                    b.Navigation("rezervasyonlar");
                });
#pragma warning restore 612, 618
        }
    }
}
