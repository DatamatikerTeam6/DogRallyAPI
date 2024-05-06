using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogRallyAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseSideShift = table.Column<bool>(type: "bit", nullable: false),
                    ExerciseIllustrationPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseClassEnumID = table.Column<int>(type: "int", nullable: false),
                    ExerciseMovementEnumID = table.Column<int>(type: "int", nullable: false),
                    ExerciseSignNumber = table.Column<int>(type: "int", nullable: false),
                    ExercisePositionX = table.Column<double>(type: "float", nullable: false),
                    ExercisePositionY = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseID);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    TrackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.TrackID);
                });

            migrationBuilder.CreateTable(
                name: "TrackExercise",
                columns: table => new
                {
                    ExerciseID = table.Column<int>(type: "int", nullable: false),
                    TrackID = table.Column<int>(type: "int", nullable: false),
                    TrackExercisePositionX = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    TrackExercisePositionY = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    TrackExerciseIllustrationPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackExercise", x => new { x.TrackID, x.ExerciseID });
                    table.ForeignKey(
                        name: "FK_TrackExercise_Exercise_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackExercise_Track_TrackID",
                        column: x => x.TrackID,
                        principalTable: "Track",
                        principalColumn: "TrackID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackExercise_Track_TrackID1",
                        column: x => x.TrackID1,
                        principalTable: "Track",
                        principalColumn: "TrackID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackExercise_ExerciseID",
                table: "TrackExercise",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_TrackExercise_TrackID1",
                table: "TrackExercise",
                column: "TrackID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackExercise");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Track");
        }
    }
}
