namespace DogRallyAPI.Models
{
    public class TrackExercise
    {
        // Join table
        // Declaration of public properties

        // Foreign keys
        public int  ForeignExerciseID { get; set; }
        public int ForeignTrackID {  get; set; }

        // Payload
        public double TrackExercisePositionX { get; set; }
        public double TrackExercisePositionY { get; set; }

        // Navigation properties
        public Track Track { get; set; }
        public Exercise Exercise { get; set; }
    }
}

