using Microsoft.EntityFrameworkCore.Migrations;

namespace AnfangAPI.Migrations
{
    public partial class seed_table_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NodeTypes",
                columns: new[] { "Id", "NodeTypeId", "NodeTypeName" },
                values: new object[] { 3, 3, "Humidity Sensor" });

            migrationBuilder.InsertData(
                table: "NodeTypes",
                columns: new[] { "Id", "NodeTypeId", "NodeTypeName" },
                values: new object[] { 4, 4, "Temperature Sensor" });

            migrationBuilder.InsertData(
                table: "NodeTypes",
                columns: new[] { "Id", "NodeTypeId", "NodeTypeName" },
                values: new object[] { 5, 5, "Door Sensor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
