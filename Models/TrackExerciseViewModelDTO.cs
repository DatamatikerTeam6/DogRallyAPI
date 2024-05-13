using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DogRallyAPI.Models
{
    public class TrackExerciseViewModelDTO
    {
        //[JsonPropertyName("trackExercises")]
        //[Required]
        //public List<TrackExercise> TrackExercises { get; set; }

        [JsonPropertyName("exercises")]
        [Required]
        public List<ExerciseDTO> Exercises { get; set; }

        [JsonPropertyName("track")]
        [Required]
        public TrackDTO Track { get; set; }
    }
}
