namespace DogRallyAPI.Models
{
    public class Track
    {
        // Declaration of public properties
        public int TrackID { get; set; }
        public string? TrackName { get; set; }
        public DateTime TrackDate { get; set; }

        // Navigation properties
        public List<Exercise> Exercises { get; set; }
        public List<TrackExercise> TrackExercises { get; } = [];
    }
}
