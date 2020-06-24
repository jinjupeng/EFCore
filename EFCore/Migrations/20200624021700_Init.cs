using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IsMenu = table.Column<bool>(nullable: false),
                    IsHide = table.Column<bool>(nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false, comment: "接口id"),
                    OrderSort = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    CreateId = table.Column<int>(nullable: true),
                    CreateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateId = table.Column<int>(nullable: true),
                    UpdateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Url = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Area = table.Column<string>(unicode: false, nullable: true),
                    Controller = table.Column<string>(unicode: false, nullable: true),
                    Action = table.Column<string>(unicode: false, nullable: true),
                    Icon = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Code = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    OrderSort = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IsMenu = table.Column<bool>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreateId = table.Column<int>(nullable: true),
                    CreateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateId = table.Column<int>(nullable: true),
                    UpdateName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(nullable: true),
                    ModuleId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false),
                    CreateId = table.Column<int>(nullable: true),
                    CreateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateId = table.Column<int>(nullable: true),
                    UpdateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: true),
                    RoleName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    OrderSort = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreateId = table.Column<int>(nullable: true),
                    CreateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateId = table.Column<int>(nullable: true),
                    UpdateName = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleModuleMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: true),
                    CreateId = table.Column<int>(nullable: true),
                    CreateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateId = table.Column<int>(nullable: true),
                    UpdateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModuleMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(unicode: false, maxLength: 32, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Grade = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Age = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateUserId = table.Column<string>(unicode: false, maxLength: 32, nullable: true),
                    UpdateUserId = table.Column<string>(unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginName = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    TrueName = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(unicode: false, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastErrTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ErrorCount = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreateId = table.Column<int>(nullable: true),
                    CreateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateId = table.Column<int>(nullable: true),
                    UpdateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "ModuleMenu");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RoleModuleMenu");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
