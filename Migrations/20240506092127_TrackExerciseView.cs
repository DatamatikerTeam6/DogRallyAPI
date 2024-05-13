using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogRallyAPI.Migrations
{
    /// <inheritdoc />
    public partial class TrackExerciseView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrackExerciseIllustrationPath",
                table: "TrackExercise",
                newName: "TrackName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrackName",
                table: "TrackExercise",
                newName: "TrackExerciseIllustrationPath");
        }
    }
}
