using Microsoft.EntityFrameworkCore.Migrations;

namespace AnfangAPI.Migrations
{
    public partial class remove_data_col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Nodes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Nodes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
