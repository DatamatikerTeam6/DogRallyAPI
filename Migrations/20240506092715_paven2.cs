using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogRallyAPI.Migrations
{
    /// <inheritdoc />
    public partial class paven2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackName",
                table: "TrackExercise");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrackName",
                table: "TrackExercise",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
