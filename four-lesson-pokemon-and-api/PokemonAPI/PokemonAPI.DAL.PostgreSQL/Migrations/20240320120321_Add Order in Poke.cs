using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI.DAL.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderinPoke : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Pokemons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Pokemons");
        }
    }
}
