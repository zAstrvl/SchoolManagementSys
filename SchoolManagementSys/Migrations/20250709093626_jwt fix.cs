using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class jwtfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Parents");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAoIr7pOPPDCjfwEeIBn+4DakSyPX6CD7C5JS+Qkiu21RW3KBe6Bt6BJP/RmviyBIg==");

            migrationBuilder.UpdateData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOai/eZ7aNIYoupuCLqetIcttf90L21XFenLB8IqrFziV9nU9tkPNTVFXUxFQM7/mw==");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdentityNumber", "PasswordHash" },
                values: new object[] { "12345678901", "AQAAAAIAAYagAAAAEEaGXS08ryTnpoj3oUqiTWPugZEEWIf78g1eejhe05cj4dg+8t6R8DtHwECQknGaQA==" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IdentityNumber", "PasswordHash" },
                values: new object[] { "12345678901", "AQAAAAIAAYagAAAAEI/kfQKWm1yfGTz8gwWnsoTjF7PGiNg8Mk2M1E/ioHJrNjvAkKytWyCu19qBtpWXLg==" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IdentityNumber", "PasswordHash" },
                values: new object[] { "12345678901", "AQAAAAIAAYagAAAAEM1bmqK5r31JEQin6fkQDlcF6bqiT4urbkepKizUiRoTXWmLYfEodPYNk4FXSOOBgA==" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IdentityNumber", "PasswordHash" },
                values: new object[] { "12345678901", "AQAAAAIAAYagAAAAEMMEQmmFgtqO4QJEX5WzkxKhEoL7iFE4dfPr2olZOjhidG5gL2uRdtNRYW+Ztd9kuw==" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENeRM7xuzloSPSEzLc+ik6LZ60xTCVlTuZRrk2Evp053eneBvFHvqS1nHtSstuejOg==");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPW55/UpbegLf+QuXY/M7qfIHR2tflYw1iw4QQG2WmPzD+um7Bgv+cRlCC7A7kyVLw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Parents");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "asd123");

            migrationBuilder.UpdateData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "3441431");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdentityNumber", "Password" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IdentityNumber", "Password" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IdentityNumber", "Password" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IdentityNumber", "Password" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: null);
        }
    }
}
