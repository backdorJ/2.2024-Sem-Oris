using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewEntityUserInfoFixMigrationsSecondPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_AspNetUsers_UserId",
                table: "UserInfos");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_AspNetUsers_UserId",
                table: "UserInfos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_AspNetUsers_UserId",
                table: "UserInfos");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_AspNetUsers_UserId",
                table: "UserInfos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
