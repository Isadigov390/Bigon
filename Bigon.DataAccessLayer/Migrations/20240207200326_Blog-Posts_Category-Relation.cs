using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bigon.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class BlogPosts_CategoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Categories_CategoryId",
                table: "BlogPosts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Categories_CategoryId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts");
        }
    }
}
