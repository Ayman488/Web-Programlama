using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class SehirYol1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KalkisSehir",
                table: "Yollar");

            migrationBuilder.DropColumn(
                name: "VarisSehri",
                table: "Yollar");

            migrationBuilder.AddColumn<int>(
                name: "KalkisSehirId",
                table: "Yollar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VarisSehirId",
                table: "Yollar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Yollar_KalkisSehirId",
                table: "Yollar",
                column: "KalkisSehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Yollar_VarisSehirId",
                table: "Yollar",
                column: "VarisSehirId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yollar_sehirler_KalkisSehirId",
                table: "Yollar",
                column: "KalkisSehirId",
                principalTable: "sehirler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yollar_sehirler_VarisSehirId",
                table: "Yollar",
                column: "VarisSehirId",
                principalTable: "sehirler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yollar_sehirler_KalkisSehirId",
                table: "Yollar");

            migrationBuilder.DropForeignKey(
                name: "FK_Yollar_sehirler_VarisSehirId",
                table: "Yollar");

            migrationBuilder.DropIndex(
                name: "IX_Yollar_KalkisSehirId",
                table: "Yollar");

            migrationBuilder.DropIndex(
                name: "IX_Yollar_VarisSehirId",
                table: "Yollar");

            migrationBuilder.DropColumn(
                name: "KalkisSehirId",
                table: "Yollar");

            migrationBuilder.DropColumn(
                name: "VarisSehirId",
                table: "Yollar");

            migrationBuilder.AddColumn<string>(
                name: "KalkisSehir",
                table: "Yollar",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VarisSehri",
                table: "Yollar",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
