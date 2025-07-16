using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class fixedemailmodelagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiBaseUrl",
                table: "MailData");

            migrationBuilder.DropColumn(
                name: "ApiToken",
                table: "MailData");

            migrationBuilder.DropColumn(
                name: "EmailToId",
                table: "MailData");

            migrationBuilder.RenameColumn(
                name: "EmailToName",
                table: "MailData",
                newName: "EmailTo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailTo",
                table: "MailData",
                newName: "EmailToName");

            migrationBuilder.AddColumn<string>(
                name: "ApiBaseUrl",
                table: "MailData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApiToken",
                table: "MailData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailToId",
                table: "MailData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
