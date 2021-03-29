using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evans.Blog.Migrations
{
    public partial class Add_Avatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "es_post",
                type: "datetime(6)",
                nullable: false,
                comment: "The creation time",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldComment: "The creation time");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "es_post",
                type: "longtext",
                nullable: true,
                comment: "The avatar of blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "es_post");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "es_post",
                type: "datetime",
                nullable: false,
                comment: "The creation time",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldComment: "The creation time");
        }
    }
}
