using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageInUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "UserInfos",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_ImageId",
                table: "UserInfos",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_MediaFiles_ImageId",
                table: "UserInfos",
                column: "ImageId",
                principalTable: "MediaFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_MediaFiles_ImageId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_ImageId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "UserInfos");
        }
    }
}
