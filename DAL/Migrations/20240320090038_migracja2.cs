using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class migracja2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ORDERPOSITION",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ORDERPOSITION_ProductID",
                table: "ORDERPOSITION",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERPOSITION_PRODUCT_ProductID",
                table: "ORDERPOSITION",
                column: "ProductID",
                principalTable: "PRODUCT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDERPOSITION_PRODUCT_ProductID",
                table: "ORDERPOSITION");

            migrationBuilder.DropIndex(
                name: "IX_ORDERPOSITION_ProductID",
                table: "ORDERPOSITION");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ORDERPOSITION");
        }
    }
}
