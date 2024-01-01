using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class SehirYol1112 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_Yollar_SYolID",
                table: "Rezervasyonlar");

            migrationBuilder.RenameColumn(
                name: "SYolID",
                table: "Rezervasyonlar",
                newName: "VarisSehir");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervasyonlar_SYolID",
                table: "Rezervasyonlar",
                newName: "IX_Rezervasyonlar_VarisSehir");

            migrationBuilder.AddColumn<int>(
                name: "KalkisSehir",
                table: "Rezervasyonlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_KalkisSehir",
                table: "Rezervasyonlar",
                column: "KalkisSehir");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_Yollar_KalkisSehir",
                table: "Rezervasyonlar",
                column: "KalkisSehir",
                principalTable: "Yollar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_Yollar_VarisSehir",
                table: "Rezervasyonlar",
                column: "VarisSehir",
                principalTable: "Yollar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_Yollar_KalkisSehir",
                table: "Rezervasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_Yollar_VarisSehir",
                table: "Rezervasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyonlar_KalkisSehir",
                table: "Rezervasyonlar");

            migrationBuilder.DropColumn(
                name: "KalkisSehir",
                table: "Rezervasyonlar");

            migrationBuilder.RenameColumn(
                name: "VarisSehir",
                table: "Rezervasyonlar",
                newName: "SYolID");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervasyonlar_VarisSehir",
                table: "Rezervasyonlar",
                newName: "IX_Rezervasyonlar_SYolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_Yollar_SYolID",
                table: "Rezervasyonlar",
                column: "SYolID",
                principalTable: "Yollar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
