using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAuthAPI.Migrations
{
    public partial class up1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsertId",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InsertId",
                table: "Printer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InsertId",
                table: "FoodMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InsertId",
                table: "DailyFood",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InsertId",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "InsertId",
                table: "Printer");

            migrationBuilder.DropColumn(
                name: "InsertId",
                table: "FoodMaster");

            migrationBuilder.DropColumn(
                name: "InsertId",
                table: "DailyFood");

            migrationBuilder.DropColumn(
                name: "InsertId",
                table: "Account");
        }
    }
}
