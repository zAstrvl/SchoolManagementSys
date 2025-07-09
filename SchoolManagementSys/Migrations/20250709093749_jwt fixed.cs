using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class jwtfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Name", "PasswordHash", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "123 Main St, Ankara", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fffroedasf@fafd.cc", "Ahmet", "AQAAAAIAAYagAAAAEAoIr7pOPPDCjfwEeIBn+4DakSyPX6CD7C5JS+Qkiu21RW3KBe6Bt6BJP/RmviyBIg==", "4512512342134", "Yılmaz" },
                    { 2, "Nilüfer, Bursa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fdasdfsa@12fadfa.daer", "Fatih", "AQAAAAIAAYagAAAAEOai/eZ7aNIYoupuCLqetIcttf90L21XFenLB8IqrFziV9nU9tkPNTVFXUxFQM7/mw==", "451234", "Arslan" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "IdentityNumber", "Name", "PasswordHash", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2004, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345678901", "Eren", "AQAAAAIAAYagAAAAEEaGXS08ryTnpoj3oUqiTWPugZEEWIf78g1eejhe05cj4dg+8t6R8DtHwECQknGaQA==", "Arslan" },
                    { 2, new DateTime(2000, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345678901", "Miraç Can", "AQAAAAIAAYagAAAAEI/kfQKWm1yfGTz8gwWnsoTjF7PGiNg8Mk2M1E/ioHJrNjvAkKytWyCu19qBtpWXLg==", "Yüksel" },
                    { 3, new DateTime(1981, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345678901", "Kürşat", "AQAAAAIAAYagAAAAEM1bmqK5r31JEQin6fkQDlcF6bqiT4urbkepKizUiRoTXWmLYfEodPYNk4FXSOOBgA==", "Özel" },
                    { 4, new DateTime(1993, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345678901", "Ömer Can", "AQAAAAIAAYagAAAAEMMEQmmFgtqO4QJEX5WzkxKhEoL7iFE4dfPr2olZOjhidG5gL2uRdtNRYW+Ztd9kuw==", "Yiğit" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "DateOfBirth", "Email", "Graduated", "Name", "PasswordHash", "PhoneNumber", "Subject", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "fsadfasfas@aasdfasddas.cascas", "Ankara University", "Ali", "AQAAAAIAAYagAAAAENeRM7xuzloSPSEzLc+ik6LZ60xTCVlTuZRrk2Evp053eneBvFHvqS1nHtSstuejOg==", "123456789013234", "Mathematics", "Demir" },
                    { 2, new DateTime(1984, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "fadfas@aasrewdff.aascas", "Istanbul University", "Veli", "AQAAAAIAAYagAAAAEPW55/UpbegLf+QuXY/M7qfIHR2tflYw1iw4QQG2WmPzD+um7Bgv+cRlCC7A7kyVLw==", "123451308224", "Physics", "Demirci" }
                });
        }
    }
}
