using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class heroesanddtomigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_HeroId",
                table: "Heroes",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Heroes_HeroId",
                table: "Heroes",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Heroes_HeroId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_HeroId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Heroes");
        }
    }
}
