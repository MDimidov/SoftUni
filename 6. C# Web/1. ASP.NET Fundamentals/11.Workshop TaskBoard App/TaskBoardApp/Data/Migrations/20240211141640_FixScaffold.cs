using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class FixScaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17d96776-448e-4106-a790-76bc47502a79");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Dectipriton",
                table: "Tasks",
                newName: "Decription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decription",
                table: "Tasks",
                newName: "Dectipriton");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "17d96776-448e-4106-a790-76bc47502a79", 0, "072b5e1f-2504-4f37-ac97-c1412a175bbb", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEDf0gAqMmgAqiDbB/PNluefSky28epzNBwz4yoKFoBryskLhTb/PxgV6dcukcrYfKA==", null, false, "485d43f7-4e56-4ec4-bc60-f3b5ec60ce19", false, "test@softuni.bg" });

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
                columns: new[] { "Id", "BoardId", "CreatedOn", "Dectipriton", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 25, 16, 1, 27, 713, DateTimeKind.Local).AddTicks(2986), "Implement better styling for all public pages", "17d96776-448e-4106-a790-76bc47502a79", "Improve CSS Styles" },
                    { 2, 1, new DateTime(2023, 9, 10, 16, 1, 27, 713, DateTimeKind.Local).AddTicks(3034), "Create Android client app for the TaskBoard RESTful API", "17d96776-448e-4106-a790-76bc47502a79", "Android Client App" },
                    { 3, 2, new DateTime(2024, 1, 10, 16, 1, 27, 713, DateTimeKind.Local).AddTicks(3040), "Create Windows Forms app for the TaskBoard RESTful API", "17d96776-448e-4106-a790-76bc47502a79", "Desctop Client App" },
                    { 4, 3, new DateTime(2023, 2, 10, 16, 1, 27, 713, DateTimeKind.Local).AddTicks(3045), "Implement [Create Task] page for adding new tasks", "17d96776-448e-4106-a790-76bc47502a79", "Create Tasks" }
                });
        }
    }
}
