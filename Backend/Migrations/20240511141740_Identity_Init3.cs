using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class Identity_Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_ProductId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ProductId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Comment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductId",
                table: "Comment",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product_ProductId",
                table: "Comment",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
