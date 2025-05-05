using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Amenity", "Area", "CreatedAt", "Details", "ImageUrl", "Name", "Ocupancy", "Rate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "too many", 200, new DateTime(2025, 5, 5, 13, 3, 26, 254, DateTimeKind.Local).AddTicks(9559), "toomuch", "1.jpg", "Ziad", 9, "5 stars", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "too many", 200, new DateTime(2025, 5, 5, 13, 3, 26, 254, DateTimeKind.Local).AddTicks(9604), "toomuch", "2.jpg", "Nadine", 9, "5 stars", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "too many", 200, new DateTime(2025, 5, 5, 13, 3, 26, 254, DateTimeKind.Local).AddTicks(9607), "toomuch", "3.jpg", "Nour", 9, "5 stars", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "too many", 200, new DateTime(2025, 5, 5, 13, 3, 26, 254, DateTimeKind.Local).AddTicks(9609), "toomuch", "4.jpg", "Amr", 9, "5 stars", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "too many", 200, new DateTime(2025, 5, 5, 13, 3, 26, 254, DateTimeKind.Local).AddTicks(9611), "toomuch", "5.jpg", "Darine", 9, "5 stars", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
