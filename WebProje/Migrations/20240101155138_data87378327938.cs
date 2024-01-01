using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class data87378327938 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UcakId",
                table: "Yollar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KalkisSehirId",
                table: "Rezervasyonlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VarisSehirId",
                table: "Rezervasyonlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Yollar_UcakId",
                table: "Yollar",
                column: "UcakId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yollar_Ucaklar_UcakId",
                table: "Yollar",
                column: "UcakId",
                principalTable: "Ucaklar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yollar_Ucaklar_UcakId",
                table: "Yollar");

            migrationBuilder.DropIndex(
                name: "IX_Yollar_UcakId",
                table: "Yollar");

            migrationBuilder.DropColumn(
                name: "UcakId",
                table: "Yollar");

            migrationBuilder.DropColumn(
                name: "KalkisSehirId",
                table: "Rezervasyonlar");

            migrationBuilder.DropColumn(
                name: "VarisSehirId",
                table: "Rezervasyonlar");
        }
    }
}
