using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DogRallyAPI.Models
{
    public class TrackExerciseDTO
    {
        // Join table
        // Declaration of public properties
 

        // Foreign keys
        [JsonPropertyName("foreignExerciseID")]
        [Required]
        public int ForeignExerciseID { get; set; }

        [JsonPropertyName("foreignTrackID")]
        [Required]
        public int ForeignTrackID {  get; set; }

        [JsonPropertyName("trackName")]
        public string? TrackName { get; set; }

        [JsonPropertyName("exerciseIllustrationPath")]
        public string? ExerciseIllustrationPath { get; set;}

        // Payload
        [JsonPropertyName("trackExercisePositionX")]
        [Required]
        public double TrackExercisePositionX { get; set; }

        [JsonPropertyName("trackExercisePositionY")]
        [Required]
        public double TrackExercisePositionY { get; set; }
    }
}
