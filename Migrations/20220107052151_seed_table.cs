using Microsoft.EntityFrameworkCore.Migrations;

namespace AnfangAPI.Migrations
{
    public partial class seed_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NodeTypes",
                columns: new[] { "Id", "NodeTypeId", "NodeTypeName" },
                values: new object[,]
                {
                    { 1, 1, "Plug" },
                    { 2, 2, "Light" },
                    { 3, 3, "Humidity Sensor" },
                    { 4, 4, "Temperature Sensor" },
                    { 5, 5, "Door Sensor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NodeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NodeTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NodeTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NodeTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NodeTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
