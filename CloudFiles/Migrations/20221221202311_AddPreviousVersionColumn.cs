using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudFiles.Migrations
{
    /// <inheritdoc />
    public partial class AddPreviousVersionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreviousVersionId",
                table: "UserFiles",
                type: "INTEGER",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousVersionId",
                table: "UserFiles");
        }
    }
}
