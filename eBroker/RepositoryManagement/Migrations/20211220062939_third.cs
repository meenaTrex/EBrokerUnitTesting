using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryManagement.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Funds",
                columns: new[] { "Id", "Amount", "TraderId" },
                values: new object[,]
                {
                    { 1, 200000.0, 1 },
                    { 2, 1500000.0, 2 },
                    { 3, 250000.0, 3 }
                });

            migrationBuilder.InsertData(
                table: "Traders",
                columns: new[] { "TraderId", "Name" },
                values: new object[,]
                {
                    { 1, "Chris" },
                    { 2, "Alisha" },
                    { 3, "Dodger" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Traders",
                keyColumn: "TraderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Traders",
                keyColumn: "TraderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Traders",
                keyColumn: "TraderId",
                keyValue: 3);
        }
    }
}
