using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_havalemaniler_sehirler_SehirId",
                table: "havalemaniler");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_Ucaklar_UcakId",
                table: "Rezervasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_Yollar_YolId",
                table: "Rezervasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_yeniKullancis_YolcuAdiId",
                table: "Rezervasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyonlar_UcakId",
                table: "Rezervasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyonlar_YolId",
                table: "Rezervasyonlar");

            migrationBuilder.DropColumn(
                name: "UcakId",
                table: "Rezervasyonlar");

            migrationBuilder.DropColumn(
                name: "Sehir",
                table: "havalemaniler");

            migrationBuilder.RenameColumn(
                name: "YolcuAdiId",
                table: "Rezervasyonlar",
                newName: "YolcuID");

            migrationBuilder.RenameColumn(
                name: "YolId",
                table: "Rezervasyonlar",
                newName: "SYolID");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervasyonlar_YolcuAdiId",
                table: "Rezervasyonlar",
                newName: "IX_Rezervasyonlar_YolcuID");

            migrationBuilder.AddColumn<int>(
                name: "Id1",
                table: "Rezervasyonlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SehirId",
                table: "havalemaniler",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_Id1",
                table: "Rezervasyonlar",
                column: "Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_Ucak",
                table: "Rezervasyonlar",
                column: "Ucak");

            migrationBuilder.AddForeignKey(
                name: "FK_havalemaniler_sehirler_SehirId",
                table: "havalemaniler",
                column: "SehirId",
                principalTable: "sehirler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_Ucaklar_Ucak",
                table: "Rezervasyonlar",
                column: "Ucak",
                principalTable: "Ucaklar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_Yollar_Id1",
                table: "Rezervasyonlar",
                column: "Id1",
                principalTable: "Yollar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_yeniKullancis_YolcuID",
                table: "Rezervasyonlar",
                column: "YolcuID",
                principalTable: "yeniKullancis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_havalemaniler_sehirler_SehirId",
                table: "havalemaniler");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_Ucaklar_Ucak",
                table: "Rezervasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_Yollar_Id1",
                table: "Rezervasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_yeniKullancis_YolcuID",
                table: "Rezervasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyonlar_Id1",
                table: "Rezervasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyonlar_Ucak",
                table: "Rezervasyonlar");

            migrationBuilder.DropColumn(
                name: "Id1",
                table: "Rezervasyonlar");

            migrationBuilder.RenameColumn(
                name: "YolcuID",
                table: "Rezervasyonlar",
                newName: "YolcuAdiId");

            migrationBuilder.RenameColumn(
                name: "SYolID",
                table: "Rezervasyonlar",
                newName: "YolId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervasyonlar_YolcuID",
                table: "Rezervasyonlar",
                newName: "IX_Rezervasyonlar_YolcuAdiId");

            migrationBuilder.AddColumn<int>(
                name: "UcakId",
                table: "Rezervasyonlar",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SehirId",
                table: "havalemaniler",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Sehir",
                table: "havalemaniler",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_UcakId",
                table: "Rezervasyonlar",
                column: "UcakId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_YolId",
                table: "Rezervasyonlar",
                column: "YolId");

            migrationBuilder.AddForeignKey(
                name: "FK_havalemaniler_sehirler_SehirId",
                table: "havalemaniler",
                column: "SehirId",
                principalTable: "sehirler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_Ucaklar_UcakId",
                table: "Rezervasyonlar",
                column: "UcakId",
                principalTable: "Ucaklar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_Yollar_YolId",
                table: "Rezervasyonlar",
                column: "YolId",
                principalTable: "Yollar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_yeniKullancis_YolcuAdiId",
                table: "Rezervasyonlar",
                column: "YolcuAdiId",
                principalTable: "yeniKullancis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
