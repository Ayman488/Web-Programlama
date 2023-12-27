using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_Yollar_Id1",
                table: "Rezervasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyonlar_Id1",
                table: "Rezervasyonlar");

            migrationBuilder.DropColumn(
                name: "Id1",
                table: "Rezervasyonlar");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_SYolID",
                table: "Rezervasyonlar",
                column: "SYolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_Yollar_SYolID",
                table: "Rezervasyonlar",
                column: "SYolID",
                principalTable: "Yollar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_Yollar_SYolID",
                table: "Rezervasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyonlar_SYolID",
                table: "Rezervasyonlar");

            migrationBuilder.AddColumn<int>(
                name: "Id1",
                table: "Rezervasyonlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_Id1",
                table: "Rezervasyonlar",
                column: "Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_Yollar_Id1",
                table: "Rezervasyonlar",
                column: "Id1",
                principalTable: "Yollar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
