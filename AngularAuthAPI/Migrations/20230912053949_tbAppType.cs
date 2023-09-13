using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAuthAPI.Migrations
{
    public partial class tbAppType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbAppType",
                columns: table => new
                {
                    App_TypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    App_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAppType", x => x.App_TypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAppType");
        }
    }
}
