using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bigon.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ContactPosts3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ContactPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ContactPosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "ContactPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "ContactPosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "ContactPosts",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ContactPosts");
        }
    }
}
