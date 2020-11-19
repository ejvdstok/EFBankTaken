using Microsoft.EntityFrameworkCore.Migrations;

namespace Model1.Migrations
{
    public partial class InitialSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Klanten",
                columns: new[] { "KlantId", "Naam" },
                values: new object[,]
                {
                    { 1, "Marge" },
                    { 2, "Homer" },
                    { 3, "Lisa" },
                    { 4, "Maggie" },
                    { 5, "Bart" }
                });

            migrationBuilder.InsertData(
                table: "Rekeningen",
                columns: new[] { "RekeningId", "KlantId", "RekeningNr", "Saldo", "Soort" },
                values: new object[] { 1, 1, "BE68 1234 5678 9012", 1000m, "Z" });

            migrationBuilder.InsertData(
                table: "Rekeningen",
                columns: new[] { "RekeningId", "KlantId", "RekeningNr", "Saldo", "Soort" },
                values: new object[] { 2, 1, "BE68 2345 6789 0169", 2000m, "S" });

            migrationBuilder.InsertData(
                table: "Rekeningen",
                columns: new[] { "RekeningId", "KlantId", "RekeningNr", "Saldo", "Soort" },
                values: new object[] { 3, 2, "BE68 3456 7890 1212", 500m, "S" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Klanten",
                keyColumn: "KlantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Klanten",
                keyColumn: "KlantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Klanten",
                keyColumn: "KlantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rekeningen",
                keyColumn: "RekeningId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rekeningen",
                keyColumn: "RekeningId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rekeningen",
                keyColumn: "RekeningId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Klanten",
                keyColumn: "KlantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klanten",
                keyColumn: "KlantId",
                keyValue: 2);
        }
    }
}
