using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddedTAblesWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46d9950e-e297-4993-894a-2c7b990f11ca", 0, "8ac45ec2-d1dd-4781-9c9f-5c9181172f7e", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAELnPHPW22EyBsoCNg938irVFGrDF4kPwE+K3HgSUw3eoMpzG/yrbrpRvRXpTArcyFA==", null, false, "20fca174-d89f-4eb6-949b-932754ec680d", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 31, 16, 8, 31, 331, DateTimeKind.Local).AddTicks(2276), "Implement better styling for all public pages", "46d9950e-e297-4993-894a-2c7b990f11ca", "Improve CSS Styles" },
                    { 2, 1, new DateTime(2023, 9, 16, 16, 8, 31, 331, DateTimeKind.Local).AddTicks(2321), "Create Android client app for the TaskBoard RESTful API", "46d9950e-e297-4993-894a-2c7b990f11ca", "Android Client App" },
                    { 3, 2, new DateTime(2024, 1, 16, 16, 8, 31, 331, DateTimeKind.Local).AddTicks(2328), "Create Windows Forms app for the TaskBoard RESTful API", "46d9950e-e297-4993-894a-2c7b990f11ca", "Desctop Client App" },
                    { 4, 3, new DateTime(2023, 2, 16, 16, 8, 31, 331, DateTimeKind.Local).AddTicks(2332), "Implement [Create Task] page for adding new tasks", "46d9950e-e297-4993-894a-2c7b990f11ca", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46d9950e-e297-4993-894a-2c7b990f11ca");
        }
    }
}
