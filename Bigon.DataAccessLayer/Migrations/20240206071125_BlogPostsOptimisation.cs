using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bigon.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class BlogPostsOptimisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "ApprovedBy",
                table: "BlogPosts",
                newName: "PublishedBy");

            migrationBuilder.RenameColumn(
                name: "ApprovedAt",
                table: "BlogPosts",
                newName: "PublishedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishedBy",
                table: "BlogPosts",
                newName: "ApprovedBy");

            migrationBuilder.RenameColumn(
                name: "PublishedAt",
                table: "BlogPosts",
                newName: "ApprovedAt");

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
