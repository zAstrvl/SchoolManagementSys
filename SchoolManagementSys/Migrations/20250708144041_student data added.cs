using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class studentdataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2004, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eren", "Arslan" },
                    { 2, new DateTime(2000, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miraç Can", "Yüksel" },
                    { 3, new DateTime(1981, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kürşat", "Özel" },
                    { 4, new DateTime(1993, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ömer Can", "Yiğit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
