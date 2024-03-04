using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaborationVG.Migrations
{
    /// <inheritdoc />
    public partial class AddedQuantityToCartBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartBooks",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartBooks");
        }
    }
}
