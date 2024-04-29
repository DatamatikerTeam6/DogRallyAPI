﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DogRallyAPI.Models
{
    public class ExerciseDTO
    {
        // Serialization
        // Validation & Data Annotation
        // Declaration of public properties

        [JsonPropertyName ("exerciseID")]
        [Required]
        [Range (1, int.MaxValue, ErrorMessage = "Exercise ID must be greater than 0")]
        public int ExerciseID { get; set; }

        [JsonPropertyName("exerciseIllustrationPath")]
        [Required]
        public string ExerciseIllustrationPath { get; set; }

        [JsonPropertyName ("exercisePositionX")]
        [Required]
        public string ExercisePositionX { get; set; }

        [JsonPropertyName("exercisePositionY")]
        [Required]
        public string ExercisePositionY { get; set; }
    }
}
