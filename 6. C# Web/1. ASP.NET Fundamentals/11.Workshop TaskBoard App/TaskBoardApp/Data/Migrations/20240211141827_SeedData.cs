using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "04d5be8a-616c-4cc5-bd10-0ef51a5f61f1", 0, "de9926d9-764d-4f07-a5e9-c5142ce0d8d1", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEM9QJtX+E2WrLL/jVdUTgulIRrfl9meJ40scGc0GWnbN3aKM9XrH15qbnBb6MEF/wA==", null, false, "2904c374-3fe4-4e07-adbd-c1ff3bc5f652", false, "test@softuni.bg" });

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
                columns: new[] { "Id", "BoardId", "CreatedOn", "Decription", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 26, 16, 18, 27, 217, DateTimeKind.Local).AddTicks(3283), "Implement better styling for all public pages", "04d5be8a-616c-4cc5-bd10-0ef51a5f61f1", "Improve CSS Styles" },
                    { 2, 1, new DateTime(2023, 9, 11, 16, 18, 27, 217, DateTimeKind.Local).AddTicks(3331), "Create Android client app for the TaskBoard RESTful API", "04d5be8a-616c-4cc5-bd10-0ef51a5f61f1", "Android Client App" },
                    { 3, 2, new DateTime(2024, 1, 11, 16, 18, 27, 217, DateTimeKind.Local).AddTicks(3337), "Create Windows Forms app for the TaskBoard RESTful API", "04d5be8a-616c-4cc5-bd10-0ef51a5f61f1", "Desctop Client App" },
                    { 4, 3, new DateTime(2023, 2, 11, 16, 18, 27, 217, DateTimeKind.Local).AddTicks(3342), "Implement [Create Task] page for adding new tasks", "04d5be8a-616c-4cc5-bd10-0ef51a5f61f1", "Create Tasks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "04d5be8a-616c-4cc5-bd10-0ef51a5f61f1");

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
        }
    }
}
