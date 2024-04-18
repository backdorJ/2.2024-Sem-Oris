using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedMessagesINChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Chats_MediaFileId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_MediaFiles_MediaFileId1",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_MediaFileId1",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "MediaFileId1",
                table: "Chats");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_MediaFiles_MediaFileId",
                table: "Chats",
                column: "MediaFileId",
                principalTable: "MediaFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_MediaFiles_MediaFileId",
                table: "Chats");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaFileId1",
                table: "Chats",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_MediaFileId1",
                table: "Chats",
                column: "MediaFileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Chats_MediaFileId",
                table: "Chats",
                column: "MediaFileId",
                principalTable: "Chats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_MediaFiles_MediaFileId1",
                table: "Chats",
                column: "MediaFileId1",
                principalTable: "MediaFiles",
                principalColumn: "Id");
        }
    }
}
