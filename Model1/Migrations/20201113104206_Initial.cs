using Microsoft.EntityFrameworkCore.Migrations;

namespace Model1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    KlantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.KlantId);
                });

            migrationBuilder.CreateTable(
                name: "Rekeningen",
                columns: table => new
                {
                    RekeningId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RekeningNr = table.Column<string>(maxLength: 19, nullable: true),
                    KlantId = table.Column<int>(nullable: false),
                    Saldo = table.Column<decimal>(nullable: false),
                    Soort = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rekeningen", x => x.RekeningId);
                    table.ForeignKey(
                        name: "FK_Rekeningen_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "KlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rekeningen_KlantId",
                table: "Rekeningen",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Rekeningen_RekeningNr",
                table: "Rekeningen",
                column: "RekeningNr",
                unique: true,
                filter: "[RekeningNr] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rekeningen");

            migrationBuilder.DropTable(
                name: "Klanten");
        }
    }
}
