using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShoppingCartMvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class renameFeildInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Order",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Order",
                newName: "CreateDate");

            migrationBuilder.CreateTable(
                name: "TopNSoldBookModels",
                columns: table => new
                {
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalUnitSold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopNSoldBookModels");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Order",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Order",
                newName: "CreatedDate");
        }
    }
}
