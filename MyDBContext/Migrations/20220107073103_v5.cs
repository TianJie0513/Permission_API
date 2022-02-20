using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDB.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysOUMembersEFTables",
                columns: table => new
                {
                    OUMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OUID = table.Column<int>(type: "int", nullable: false),
                    UId = table.Column<int>(type: "int", nullable: false),
                    UserAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysOUMembersEFTables", x => x.OUMemberId);
                });

            migrationBuilder.CreateTable(
                name: "SysOURoleMembersEFTables",
                columns: table => new
                {
                    OURoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OUID = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAccount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysOURoleMembersEFTables", x => x.OURoleId);
                });

            migrationBuilder.CreateTable(
                name: "SysOURolesEFTables",
                columns: table => new
                {
                    OUROleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OUID = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysOURolesEFTables", x => x.OUROleID);
                });

            migrationBuilder.CreateTable(
                name: "SysUsersEFTables",
                columns: table => new
                {
                    UId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysUser = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUsersEFTables", x => x.UId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysOUMembersEFTables");

            migrationBuilder.DropTable(
                name: "SysOURoleMembersEFTables");

            migrationBuilder.DropTable(
                name: "SysOURolesEFTables");

            migrationBuilder.DropTable(
                name: "SysUsersEFTables");
        }
    }
}
