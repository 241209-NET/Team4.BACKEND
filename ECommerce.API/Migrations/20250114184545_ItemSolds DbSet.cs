using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class ItemSoldsDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSold_Orders_OrderId",
                table: "ItemSold");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemSold",
                table: "ItemSold");

            migrationBuilder.RenameTable(
                name: "ItemSold",
                newName: "ItemSolds");

            migrationBuilder.RenameIndex(
                name: "IX_ItemSold_OrderId",
                table: "ItemSolds",
                newName: "IX_ItemSolds_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemSolds",
                table: "ItemSolds",
                column: "ItemSoldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSolds_Orders_OrderId",
                table: "ItemSolds",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSolds_Orders_OrderId",
                table: "ItemSolds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemSolds",
                table: "ItemSolds");

            migrationBuilder.RenameTable(
                name: "ItemSolds",
                newName: "ItemSold");

            migrationBuilder.RenameIndex(
                name: "IX_ItemSolds_OrderId",
                table: "ItemSold",
                newName: "IX_ItemSold_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemSold",
                table: "ItemSold",
                column: "ItemSoldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSold_Orders_OrderId",
                table: "ItemSold",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
