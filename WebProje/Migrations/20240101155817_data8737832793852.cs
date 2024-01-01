using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class data8737832793852 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yollar_Ucaklar_UcakId",
                table: "Yollar");

            migrationBuilder.RenameColumn(
                name: "UcakId",
                table: "Yollar",
                newName: "UCAKID");

            migrationBuilder.RenameIndex(
                name: "IX_Yollar_UcakId",
                table: "Yollar",
                newName: "IX_Yollar_UCAKID");

            migrationBuilder.AddForeignKey(
                name: "FK_Yollar_Ucaklar_UCAKID",
                table: "Yollar",
                column: "UCAKID",
                principalTable: "Ucaklar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yollar_Ucaklar_UCAKID",
                table: "Yollar");

            migrationBuilder.RenameColumn(
                name: "UCAKID",
                table: "Yollar",
                newName: "UcakId");

            migrationBuilder.RenameIndex(
                name: "IX_Yollar_UCAKID",
                table: "Yollar",
                newName: "IX_Yollar_UcakId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yollar_Ucaklar_UcakId",
                table: "Yollar",
                column: "UcakId",
                principalTable: "Ucaklar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
