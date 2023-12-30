using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class newdata25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UcakId",
                table: "Koltuklar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Koltuklar_UcakId",
                table: "Koltuklar",
                column: "UcakId");

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuklar_Ucaklar_UcakId",
                table: "Koltuklar",
                column: "UcakId",
                principalTable: "Ucaklar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koltuklar_Ucaklar_UcakId",
                table: "Koltuklar");

            migrationBuilder.DropIndex(
                name: "IX_Koltuklar_UcakId",
                table: "Koltuklar");

            migrationBuilder.DropColumn(
                name: "UcakId",
                table: "Koltuklar");
        }
    }
}
