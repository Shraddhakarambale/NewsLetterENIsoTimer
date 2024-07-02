using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsLetterENIsoTimer.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "NewsLetters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "NewsLetters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
