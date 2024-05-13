namespace DogRallyAPI.Models
{
    public class Exercise
    {
        // Declaration of public properties
        public int ExerciseID { get; set; }
        public string? ExerciseName { get; set; }
        public bool ExerciseSideShift { get; set; }
        public string? ExerciseIllustrationPath { get; set; }
        public ClassEnum ExerciseClassEnumID { get; set; }
        public PaceEnum ExerciseMovementEnumID { get; set; }
        public int ExerciseSignNumber { get; set; }
        public double ExercisePositionX { get; set; }
        public double ExercisePositionY { get; set; }

        // Navigation properties
        public List<Track> Tracks { get; set; } 
        public List<TrackExercise> TrackExercises { get; } = [];
    }

    // Enums
    public enum ClassEnum
    {
        Beginner = 1,
        Trained = 2,
        Expert = 3,
        Champion = 4,
        Open = 5
    }

    public enum PaceEnum
    {
        Stationary = 1,
        Slow = 2,
        Walk = 3,
        Run = 4
    }
}
