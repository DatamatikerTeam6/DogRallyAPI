using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogRallyAPI.Migrations
{
    /// <inheritdoc />
    public partial class newDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseTrack");

            migrationBuilder.AlterColumn<double>(
                name: "TrackExercisePositionY",
                table: "TrackExercise",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "TrackExercisePositionX",
                table: "TrackExercise",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TrackExercisePositionY",
                table: "TrackExercise",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "TrackExercisePositionX",
                table: "TrackExercise",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ExerciseTrack",
                columns: table => new
                {
                    ExercisesExerciseID = table.Column<int>(type: "int", nullable: false),
                    TracksTrackID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTrack", x => new { x.ExercisesExerciseID, x.TracksTrackID });
                    table.ForeignKey(
                        name: "FK_ExerciseTrack_Exercise_ExercisesExerciseID",
                        column: x => x.ExercisesExerciseID,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTrack_Track_TracksTrackID",
                        column: x => x.TracksTrackID,
                        principalTable: "Track",
                        principalColumn: "TrackID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTrack_TracksTrackID",
                table: "ExerciseTrack",
                column: "TracksTrackID");
        }
    }
}
