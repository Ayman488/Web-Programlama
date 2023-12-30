using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class newdata23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sirketsId",
                table: "Ucaklar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ucaklar_sirketsId",
                table: "Ucaklar",
                column: "sirketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ucaklar_sirketler_sirketsId",
                table: "Ucaklar",
                column: "sirketsId",
                principalTable: "sirketler",
                principalColumn: "SirketId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ucaklar_sirketler_sirketsId",
                table: "Ucaklar");

            migrationBuilder.DropIndex(
                name: "IX_Ucaklar_sirketsId",
                table: "Ucaklar");

            migrationBuilder.DropColumn(
                name: "sirketsId",
                table: "Ucaklar");
        }
    }
}
