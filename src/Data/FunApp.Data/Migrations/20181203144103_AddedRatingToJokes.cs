using Microsoft.EntityFrameworkCore.Migrations;

namespace FunApp.Data.Migrations
{
    public partial class AddedRatingToJokes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Jokes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "RatingVotes",
                table: "Jokes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "RatingVotes",
                table: "Jokes");
        }
    }
}
