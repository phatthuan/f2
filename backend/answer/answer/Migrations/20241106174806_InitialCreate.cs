using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace answer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemUrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDisplayOrder = table.Column<int>(type: "int", nullable: true),
                    ItemPriceInclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderedQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_GroupID",
                table: "Items",
                column: "GroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
