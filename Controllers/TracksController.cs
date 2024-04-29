using DogRallyAPI.Data;
using DogRallyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DogRallyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TracksController : ControllerBase
    {
        private readonly DogRallyContext _context;

        public TracksController(DogRallyContext context)
        {
            _context = context;
        }

        [HttpPost("CreateTrack")]
        public async Task<IActionResult> CreateTrack([FromBody] TrackExerciseViewModelDTO viewModel)
        {
            if (ModelState.IsValid)
            {
                var track = new Track
                {
                    TrackName = viewModel.Track.TrackName,
                    TrackDate = viewModel.Track.TrackDate
                };
                _context.Tracks.Add(track);
                await _context.SaveChangesAsync(); // Create the track to acces its ID

                foreach (var exerciseInViewModel in viewModel.Exercises)
                {
                    //Check if the exercise exists
                    var exerciseExists = await _context.Exercises.AnyAsync(e => e.ExerciseID == exerciseInViewModel.ExerciseID);
                    if (exerciseExists)
                    {
                        var trackExercise = new TrackExercise
                        {
                            TrackID = track.TrackID,
                            ExerciseID = exerciseInViewModel.ExerciseID,
                            TrackExercisePositionX = double.Parse(exerciseInViewModel.ExercisePositionX),
                            TrackExercisePositionY = double.Parse(exerciseInViewModel.ExercisePositionY),
                        };
                        //Add trackExercise to database
                        _context.Add(trackExercise);
                    }
                }
                await _context.SaveChangesAsync();
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpGet("ReadExercises")]
        public async Task<IActionResult> ReadExercises()
        {
            var exercises = await _context.Exercises.ToListAsync();

            var exerciseDTOs = exercises.Select(e => new ExerciseDTO
            {
                ExerciseID = e.ExerciseID,
                ExerciseIllustrationPath = e.ExerciseIllustrationPath,
                ExercisePositionX = e.ExercisePositionX.ToString(),
                ExercisePositionY = e.ExercisePositionY.ToString()
            }); 
            return Ok(exerciseDTOs);   
        }

    }
}
