using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class data2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.CreateTable(
                name: "havalemaniler",
                columns: table => new
                {
                    HavalemanininAdi = table.Column<string>(type: "text", nullable: false),
                    Sehir = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_havalemaniler", x => x.HavalemanininAdi);
                });

            migrationBuilder.CreateTable(
                name: "sehirler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HavalemanininAdi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sehirler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sehirler_havalemaniler_HavalemanininAdi",
                        column: x => x.HavalemanininAdi,
                        principalTable: "havalemaniler",
                        principalColumn: "HavalemanininAdi");
                });

            migrationBuilder.CreateIndex(
                name: "IX_sehirler_HavalemanininAdi",
                table: "sehirler",
                column: "HavalemanininAdi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sehirler");

            migrationBuilder.DropTable(
                name: "havalemaniler");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AEmail = table.Column<string>(type: "text", nullable: false),
                    ASifre = table.Column<string>(type: "text", nullable: false),
                    AdminName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });
        }
    }
}
