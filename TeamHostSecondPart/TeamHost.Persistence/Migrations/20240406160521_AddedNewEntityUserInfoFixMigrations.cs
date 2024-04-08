using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewEntityUserInfoFixMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_AspNetUsers_UserId",
                table: "UserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Countries_CountryId",
                table: "UserInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "UserInfos");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfo_UserId",
                table: "UserInfos",
                newName: "IX_UserInfos_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfo_CountryId",
                table: "UserInfos",
                newName: "IX_UserInfos_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_AspNetUsers_UserId",
                table: "UserInfos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Countries_CountryId",
                table: "UserInfos",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_AspNetUsers_UserId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Countries_CountryId",
                table: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos");

            migrationBuilder.RenameTable(
                name: "UserInfos",
                newName: "UserInfo");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfos_UserId",
                table: "UserInfo",
                newName: "IX_UserInfo_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfos_CountryId",
                table: "UserInfo",
                newName: "IX_UserInfo_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_AspNetUsers_UserId",
                table: "UserInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Countries_CountryId",
                table: "UserInfo",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
