using Microsoft.EntityFrameworkCore.Migrations;

namespace PSGames.API.Migrations
{
    public partial class AddedGameTitleImgUrlProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameTitleImageUrl",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameTitleImageUrl",
                table: "Games");
        }
    }
}
