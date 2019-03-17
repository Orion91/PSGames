using Microsoft.EntityFrameworkCore.Migrations;

namespace PSGames.API.Migrations
{
    public partial class ChangedLibraryGamesDeleteBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersGameLibraries_Games_GameId",
                table: "UsersGameLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGameLibraries_Users_UserId",
                table: "UsersGameLibraries");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGameLibraries_Games_GameId",
                table: "UsersGameLibraries",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGameLibraries_Users_UserId",
                table: "UsersGameLibraries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersGameLibraries_Games_GameId",
                table: "UsersGameLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGameLibraries_Users_UserId",
                table: "UsersGameLibraries");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGameLibraries_Games_GameId",
                table: "UsersGameLibraries",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGameLibraries_Users_UserId",
                table: "UsersGameLibraries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
