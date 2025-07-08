using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class addedparentmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "123 Main St, Ankara", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fffroedasf@fafd.cc", "Ahmet", "4512512342134", "Yılmaz" },
                    { 2, "Nilüfer, Bursa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fdasdfsa@12fadfa.daer", "Fatih", "451234", "Arslan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
