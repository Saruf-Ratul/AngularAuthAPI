using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAuthAPI.Migrations
{
    public partial class active : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Active",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "users");
        }
    }
}
