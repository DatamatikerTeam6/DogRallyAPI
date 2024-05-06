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
                    TrackID = viewModel.Track.TrackID,
                    TrackName = viewModel.Track.TrackName,
                    TrackDate = viewModel.Track.TrackDate
                };
                _context.Tracks.Add(track);
                await _context.SaveChangesAsync(); // Create the track to access its ID

                foreach (var exerciseInViewModel in viewModel.Exercises)
                {
                    //Check if the exercise exists
                    var exerciseExists = await _context.Exercises.AnyAsync(e => e.ExerciseID == exerciseInViewModel.ExerciseID);
                    if (exerciseExists)
                    {
                        var trackExercise = new TrackExercise
                        {
                            ForeignTrackID = track.TrackID,
                            ForeignExerciseID = exerciseInViewModel.ExerciseID,
                            TrackExercisePositionX = exerciseInViewModel.ExercisePositionX,
                            TrackExercisePositionY = exerciseInViewModel.ExercisePositionY,
                        };
                        //Add trackExercise to database
                        _context.Add(trackExercise);
                    }
                }
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("ReadExercises")]
        public async Task<IActionResult> ReadExercises()
        {
            var exercises = await _context.Exercises.ToListAsync();

            var exerciseDTOs = exercises.Select(e => new ExerciseDTO
            {
                ExerciseID = e.ExerciseID,
                ExerciseIllustrationPath = e.ExerciseIllustrationPath,
                ExercisePositionX = e.ExercisePositionX,
                ExercisePositionY = e.ExercisePositionY
            });
            return Ok(exerciseDTOs);
        }

        [HttpGet("ReadTrack")]
        public async Task<IActionResult> ReadTrack(int? trackID)
        {
            if (ModelState.IsValid && trackID != null)
            {
                var trackExercises = await _context.TrackExercises.Where(te => te.ForeignTrackID == trackID).ToListAsync();
                var trackExerciseDTOs = trackExercises.Select(e => new TrackExerciseDTO
                {
                    TrackID = e.ForeignTrackID,
                    ExerciseID= e.ForeignExerciseID,
                    TrackExercisePositionX = e.TrackExercisePositionX,
                    TrackExercisePositionY = e.TrackExercisePositionY

                });
                return Ok(trackExerciseDTOs);
            }
            return BadRequest(ModelState);    

        }
    }
}
