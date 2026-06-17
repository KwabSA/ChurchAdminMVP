using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChurchAdminMVP.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Members",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Members");
        }
    }
}
