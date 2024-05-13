using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class Identity_Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_ParentConmmentId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentConmmentId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentConmmentId",
                table: "Comment");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentCommentId",
                table: "Comment",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_ParentCommentId",
                table: "Comment",
                column: "ParentCommentId",
                principalTable: "Comment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_ParentCommentId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentCommentId",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "ParentConmmentId",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentConmmentId",
                table: "Comment",
                column: "ParentConmmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_ParentConmmentId",
                table: "Comment",
                column: "ParentConmmentId",
                principalTable: "Comment",
                principalColumn: "Id");
        }
    }
}
