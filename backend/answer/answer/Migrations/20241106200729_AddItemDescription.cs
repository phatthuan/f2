using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace answer.Migrations
{
    /// <inheritdoc />
    public partial class AddItemDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "Items");
        }
    }
}
