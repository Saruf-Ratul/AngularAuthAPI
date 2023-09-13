using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularAuthAPI.Migrations
{
    public partial class tbAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apoinments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RuningMilage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apoinments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dashboards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAppointment",
                columns: table => new
                {
                    App_ID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Schedule_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Schedule_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cust_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vReg_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model_Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Reminder1_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reminder2_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reminder3_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_TypeId = table.Column<byte>(type: "tinyint", nullable: true),
                    App_Serial = table.Column<int>(type: "int", nullable: true),
                    APP_Confirm = table.Column<bool>(type: "bit", nullable: true),
                    Appby_Secu_EMPID = table.Column<int>(type: "int", nullable: true),
                    Confirmby_Secu_EMPID = table.Column<int>(type: "int", nullable: true),
                    vPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_Entry_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Print_count = table.Column<byte>(type: "tinyint", nullable: true),
                    Level_Id = table.Column<int>(type: "int", nullable: true),
                    Bay_Id = table.Column<int>(type: "int", nullable: true),
                    EMPID = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobleNO_SMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APP_Re_Confirm = table.Column<bool>(type: "bit", nullable: true),
                    Chesis_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Computer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Computer_UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SysDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAppointment", x => x.App_ID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordExpiry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apoinments");

            migrationBuilder.DropTable(
                name: "dashboards");

            migrationBuilder.DropTable(
                name: "tbAppointment");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
