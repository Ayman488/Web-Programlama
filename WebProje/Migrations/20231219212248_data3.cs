using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class data3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sehirler_havalemaniler_HavalemanininAdi",
                table: "sehirler");

            migrationBuilder.DropIndex(
                name: "IX_sehirler_HavalemanininAdi",
                table: "sehirler");

            migrationBuilder.DropColumn(
                name: "HavalemanininAdi",
                table: "sehirler");

            migrationBuilder.AddColumn<int>(
                name: "SehirId",
                table: "havalemaniler",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_havalemaniler_SehirId",
                table: "havalemaniler",
                column: "SehirId");

            migrationBuilder.AddForeignKey(
                name: "FK_havalemaniler_sehirler_SehirId",
                table: "havalemaniler",
                column: "SehirId",
                principalTable: "sehirler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_havalemaniler_sehirler_SehirId",
                table: "havalemaniler");

            migrationBuilder.DropIndex(
                name: "IX_havalemaniler_SehirId",
                table: "havalemaniler");

            migrationBuilder.DropColumn(
                name: "SehirId",
                table: "havalemaniler");

            migrationBuilder.AddColumn<string>(
                name: "HavalemanininAdi",
                table: "sehirler",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sehirler_HavalemanininAdi",
                table: "sehirler",
                column: "HavalemanininAdi");

            migrationBuilder.AddForeignKey(
                name: "FK_sehirler_havalemaniler_HavalemanininAdi",
                table: "sehirler",
                column: "HavalemanininAdi",
                principalTable: "havalemaniler",
                principalColumn: "HavalemanininAdi");
        }
    }
}
