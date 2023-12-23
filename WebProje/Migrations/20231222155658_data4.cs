using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class data4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_yeniKullancis_YolcuAdiAdi",
                table: "Rezervasyonlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_yeniKullancis",
                table: "yeniKullancis");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyonlar_YolcuAdiAdi",
                table: "Rezervasyonlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_havalemaniler",
                table: "havalemaniler");

            migrationBuilder.DropColumn(
                name: "YolcuAdiAdi",
                table: "Rezervasyonlar");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "yeniKullancis",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "YolcuAdiId",
                table: "Rezervasyonlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "havalemaniler",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_yeniKullancis",
                table: "yeniKullancis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_havalemaniler",
                table: "havalemaniler",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_YolcuAdiId",
                table: "Rezervasyonlar",
                column: "YolcuAdiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_yeniKullancis_YolcuAdiId",
                table: "Rezervasyonlar",
                column: "YolcuAdiId",
                principalTable: "yeniKullancis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_yeniKullancis_YolcuAdiId",
                table: "Rezervasyonlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_yeniKullancis",
                table: "yeniKullancis");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyonlar_YolcuAdiId",
                table: "Rezervasyonlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_havalemaniler",
                table: "havalemaniler");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "yeniKullancis");

            migrationBuilder.DropColumn(
                name: "YolcuAdiId",
                table: "Rezervasyonlar");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "havalemaniler");

            migrationBuilder.AddColumn<string>(
                name: "YolcuAdiAdi",
                table: "Rezervasyonlar",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_yeniKullancis",
                table: "yeniKullancis",
                column: "Adi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_havalemaniler",
                table: "havalemaniler",
                column: "HavalemanininAdi");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_YolcuAdiAdi",
                table: "Rezervasyonlar",
                column: "YolcuAdiAdi");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_yeniKullancis_YolcuAdiAdi",
                table: "Rezervasyonlar",
                column: "YolcuAdiAdi",
                principalTable: "yeniKullancis",
                principalColumn: "Adi",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
