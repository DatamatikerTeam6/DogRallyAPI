using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogRallyAPI.Migrations
{
    /// <inheritdoc />
    public partial class dogRally3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackExercise_Exercise_ExercisesExerciseID",
                table: "TrackExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackExercise_Track_TracksTrackID",
                table: "TrackExercise");

            migrationBuilder.DropIndex(
                name: "IX_TrackExercise_ExercisesExerciseID",
                table: "TrackExercise");

            migrationBuilder.DropIndex(
                name: "IX_TrackExercise_TracksTrackID",
                table: "TrackExercise");

            migrationBuilder.DropColumn(
                name: "ExercisesExerciseID",
                table: "TrackExercise");

            migrationBuilder.DropColumn(
                name: "TracksTrackID",
                table: "TrackExercise");

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
                name: "IX_TrackExercise_ForeignExerciseID",
                table: "TrackExercise",
                column: "ForeignExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTrack_TracksTrackID",
                table: "ExerciseTrack",
                column: "TracksTrackID");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExercise_Exercise_ForeignExerciseID",
                table: "TrackExercise",
                column: "ForeignExerciseID",
                principalTable: "Exercise",
                principalColumn: "ExerciseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExercise_Track_ForeignTrackID",
                table: "TrackExercise",
                column: "ForeignTrackID",
                principalTable: "Track",
                principalColumn: "TrackID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackExercise_Exercise_ForeignExerciseID",
                table: "TrackExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackExercise_Track_ForeignTrackID",
                table: "TrackExercise");

            migrationBuilder.DropTable(
                name: "ExerciseTrack");

            migrationBuilder.DropIndex(
                name: "IX_TrackExercise_ForeignExerciseID",
                table: "TrackExercise");

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

            migrationBuilder.AddColumn<int>(
                name: "ExercisesExerciseID",
                table: "TrackExercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TracksTrackID",
                table: "TrackExercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrackExercise_ExercisesExerciseID",
                table: "TrackExercise",
                column: "ExercisesExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_TrackExercise_TracksTrackID",
                table: "TrackExercise",
                column: "TracksTrackID");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExercise_Exercise_ExercisesExerciseID",
                table: "TrackExercise",
                column: "ExercisesExerciseID",
                principalTable: "Exercise",
                principalColumn: "ExerciseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExercise_Track_TracksTrackID",
                table: "TrackExercise",
                column: "TracksTrackID",
                principalTable: "Track",
                principalColumn: "TrackID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
