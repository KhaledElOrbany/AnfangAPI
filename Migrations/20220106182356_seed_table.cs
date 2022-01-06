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
                values: new object[] { 1, 1, "Plug" });

            migrationBuilder.InsertData(
                table: "NodeTypes",
                columns: new[] { "Id", "NodeTypeId", "NodeTypeName" },
                values: new object[] { 2, 2, "Light" });
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
        }
    }
}
