using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedGenderToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Member");
        }
    }
}
