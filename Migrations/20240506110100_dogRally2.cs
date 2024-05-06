using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogRallyAPI.Migrations
{
    /// <inheritdoc />
    public partial class dogRally2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackExercise_Exercise_ExerciseID",
                table: "TrackExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackExercise_Track_TrackID",
                table: "TrackExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackExercise_Track_TrackID1",
                table: "TrackExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackExercise",
                table: "TrackExercise");

            migrationBuilder.DropIndex(
                name: "IX_TrackExercise_TrackID1",
                table: "TrackExercise");

            migrationBuilder.DropColumn(
                name: "TrackID1",
                table: "TrackExercise");

            migrationBuilder.RenameColumn(
                name: "ExerciseID",
                table: "TrackExercise",
                newName: "TracksTrackID");

            migrationBuilder.RenameColumn(
                name: "TrackID",
                table: "TrackExercise",
                newName: "ExercisesExerciseID");

            migrationBuilder.RenameIndex(
                name: "IX_TrackExercise_ExerciseID",
                table: "TrackExercise",
                newName: "IX_TrackExercise_TracksTrackID");

            migrationBuilder.AddColumn<int>(
                name: "ForeignTrackID",
                table: "TrackExercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ForeignExerciseID",
                table: "TrackExercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackExercise",
                table: "TrackExercise",
                columns: new[] { "ForeignTrackID", "ForeignExerciseID" });

            migrationBuilder.CreateIndex(
                name: "IX_TrackExercise_ExercisesExerciseID",
                table: "TrackExercise",
                column: "ExercisesExerciseID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackExercise_Exercise_ExercisesExerciseID",
                table: "TrackExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackExercise_Track_TracksTrackID",
                table: "TrackExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackExercise",
                table: "TrackExercise");

            migrationBuilder.DropIndex(
                name: "IX_TrackExercise_ExercisesExerciseID",
                table: "TrackExercise");

            migrationBuilder.DropColumn(
                name: "ForeignTrackID",
                table: "TrackExercise");

            migrationBuilder.DropColumn(
                name: "ForeignExerciseID",
                table: "TrackExercise");

            migrationBuilder.RenameColumn(
                name: "TracksTrackID",
                table: "TrackExercise",
                newName: "ExerciseID");

            migrationBuilder.RenameColumn(
                name: "ExercisesExerciseID",
                table: "TrackExercise",
                newName: "TrackID");

            migrationBuilder.RenameIndex(
                name: "IX_TrackExercise_TracksTrackID",
                table: "TrackExercise",
                newName: "IX_TrackExercise_ExerciseID");

            migrationBuilder.AddColumn<int>(
                name: "TrackID1",
                table: "TrackExercise",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackExercise",
                table: "TrackExercise",
                columns: new[] { "TrackID", "ExerciseID" });

            migrationBuilder.CreateIndex(
                name: "IX_TrackExercise_TrackID1",
                table: "TrackExercise",
                column: "TrackID1");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExercise_Exercise_ExerciseID",
                table: "TrackExercise",
                column: "ExerciseID",
                principalTable: "Exercise",
                principalColumn: "ExerciseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExercise_Track_TrackID",
                table: "TrackExercise",
                column: "TrackID",
                principalTable: "Track",
                principalColumn: "TrackID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExercise_Track_TrackID1",
                table: "TrackExercise",
                column: "TrackID1",
                principalTable: "Track",
                principalColumn: "TrackID");
        }
    }
}
