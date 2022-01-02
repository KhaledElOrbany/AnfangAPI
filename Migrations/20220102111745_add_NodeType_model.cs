using Microsoft.EntityFrameworkCore.Migrations;

namespace AnfangAPI.Migrations
{
    public partial class add_NodeType_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WifiState",
                table: "Nodes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WifiState",
                table: "Nodes");
        }
    }
}
