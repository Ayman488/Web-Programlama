using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class DATA1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdminName = table.Column<string>(type: "text", nullable: false),
                    AEmail = table.Column<string>(type: "text", nullable: false),
                    ASifre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    Sifre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Ucaklar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KoltukSayisi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucaklar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "yeniKullancis",
                columns: table => new
                {
                    Adi = table.Column<string>(type: "text", nullable: false),
                    SoyAdi = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Sifre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yeniKullancis", x => x.Adi);
                });

            migrationBuilder.CreateTable(
                name: "Yollar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KalkisSehir = table.Column<string>(type: "text", nullable: false),
                    VarisSehri = table.Column<string>(type: "text", nullable: false),
                    KalkisZaman = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VarisZaman = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yollar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KoltukNumarasi = table.Column<int>(type: "integer", nullable: false),
                    YolId = table.Column<int>(type: "integer", nullable: false),
                    Ucak = table.Column<int>(type: "integer", nullable: false),
                    YolcuAdiAdi = table.Column<string>(type: "text", nullable: false),
                    UcakId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Ucaklar_UcakId",
                        column: x => x.UcakId,
                        principalTable: "Ucaklar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Yollar_YolId",
                        column: x => x.YolId,
                        principalTable: "Yollar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_yeniKullancis_YolcuAdiAdi",
                        column: x => x.YolcuAdiAdi,
                        principalTable: "yeniKullancis",
                        principalColumn: "Adi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_UcakId",
                table: "Rezervasyonlar",
                column: "UcakId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_YolcuAdiAdi",
                table: "Rezervasyonlar",
                column: "YolcuAdiAdi");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_YolId",
                table: "Rezervasyonlar",
                column: "YolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Ucaklar");

            migrationBuilder.DropTable(
                name: "Yollar");

            migrationBuilder.DropTable(
                name: "yeniKullancis");
        }
    }
}
