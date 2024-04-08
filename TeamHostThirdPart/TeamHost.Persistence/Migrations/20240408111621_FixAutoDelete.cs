using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixAutoDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Countries_CountryId",
                table: "Developers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Countries_CountryId",
                table: "UserInfos");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Countries_CountryId",
                table: "Developers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Countries_CountryId",
                table: "UserInfos",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Countries_CountryId",
                table: "Developers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Countries_CountryId",
                table: "UserInfos");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Countries_CountryId",
                table: "Developers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Countries_CountryId",
                table: "UserInfos",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
