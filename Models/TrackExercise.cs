namespace DogRallyAPI.Models
{
    public class TrackExercise
    {
        // Join table
        // Declaration of public properties

        // Foreign keys
        public int ExerciseID { get; set; }
        public int TrackID {  get; set; }

        // Payload
        public double TrackExercisePositionX { get; set; }
        public double TrackExercisePositionY { get; set; }
        public string TrackExerciseIllustrationPath { get; set; }
    }
}
