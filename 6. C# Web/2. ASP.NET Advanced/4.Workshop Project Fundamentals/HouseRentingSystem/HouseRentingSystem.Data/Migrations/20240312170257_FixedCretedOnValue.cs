using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class FixedCretedOnValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("6408f2b2-c5fa-40e1-90c8-1130c6bc2dff"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("9b3e6207-098b-4380-acaf-042ffb374323"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("e94126a3-ac62-4052-bf9b-8866b9d6a542"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 27, 17, 0, 49, 475, DateTimeKind.Utc).AddTicks(1055));

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("4a7dcaec-f862-488e-ad4c-73a7e133983c"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("a954c79e-446d-472b-9250-b2c033693ec9"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("6d631a35-f156-430e-a496-27db19bf109b"), "North London, UK (near the border)", new Guid("a954c79e-446d-472b-9250-b2c033693ec9"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("0d77d61c-5c5e-447a-327a-08dc37a975d9"), "Big House Marina" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("8c342ee8-115a-45b5-a067-971abaa38106"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a954c79e-446d-472b-9250-b2c033693ec9"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("4a7dcaec-f862-488e-ad4c-73a7e133983c"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("6d631a35-f156-430e-a496-27db19bf109b"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("8c342ee8-115a-45b5-a067-971abaa38106"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 27, 17, 0, 49, 475, DateTimeKind.Utc).AddTicks(1055),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("6408f2b2-c5fa-40e1-90c8-1130c6bc2dff"), "North London, UK (near the border)", new Guid("a954c79e-446d-472b-9250-b2c033693ec9"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("0d77d61c-5c5e-447a-327a-08dc37a975d9"), "Big House Marina" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("9b3e6207-098b-4380-acaf-042ffb374323"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("a954c79e-446d-472b-9250-b2c033693ec9"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("e94126a3-ac62-4052-bf9b-8866b9d6a542"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("a954c79e-446d-472b-9250-b2c033693ec9"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" });
        }
    }
}
