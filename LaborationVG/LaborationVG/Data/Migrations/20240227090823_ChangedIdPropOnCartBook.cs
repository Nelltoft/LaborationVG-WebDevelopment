using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaborationVG.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIdPropOnCartBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CartBooks",
                table: "CartBooks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CartBooks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartBooks",
                table: "CartBooks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CartBooks_CartId",
                table: "CartBooks",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CartBooks",
                table: "CartBooks");

            migrationBuilder.DropIndex(
                name: "IX_CartBooks_CartId",
                table: "CartBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CartBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartBooks",
                table: "CartBooks",
                columns: new[] { "CartId", "BookId" });
        }
    }
}
