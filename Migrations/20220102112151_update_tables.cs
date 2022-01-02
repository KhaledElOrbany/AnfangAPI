using Microsoft.EntityFrameworkCore.Migrations;

namespace AnfangAPI.Migrations
{
    public partial class update_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Brightness",
                table: "Nodes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Nodes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Limit",
                table: "Nodes",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SensorReading",
                table: "Nodes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NodeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NodeTypes");

            migrationBuilder.DropColumn(
                name: "Brightness",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "Limit",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "SensorReading",
                table: "Nodes");
        }
    }
}
