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
                var trackExerciseDTOs = await _context.TrackExerciseDTOS.Where(te => te.ForeignTrackID == trackID).ToListAsync();

                return Ok(trackExerciseDTOs);
            }
            return BadRequest(ModelState);

        }

        [HttpGet("GetUserTracks")]
        public async Task<IActionResult> GetUserTracks()
        {
            if (ModelState.IsValid)
            {
                var allUserTracks = await _context.Tracks.ToListAsync();

                var allUserTracksDTO = allUserTracks.Select(u => new TrackDTO
                {
                    TrackID = u.TrackID,
                    TrackName = u.TrackName,
                    TrackDate = u.TrackDate,
                });
                return Ok(allUserTracksDTO);
            }
            return BadRequest(ModelState);

        }

        [HttpPut("UpdateTrack")]
        public async Task<IActionResult> UpdateTrack([FromBody] TrackExerciseViewModelDTO viewModel)
        {
            if (viewModel == null || viewModel.Track == null)
            {
                return BadRequest("Invalid data.");
            }

            // Fetch the existing track from the database
            var trackToUpdate = await _context.Tracks
                .Include(t => t.TrackExercises) // Make sure to include related data
                .FirstOrDefaultAsync(t => t.TrackID == viewModel.Track.TrackID);

            if (trackToUpdate == null)
            {
                return NotFound($"Track with ID {viewModel.Track.TrackID} not found.");
            }

            // Update track properties
            trackToUpdate.TrackName = viewModel.Track.TrackName;
            trackToUpdate.TrackDate = viewModel.Track.TrackDate;

            // Update or add exercises
            foreach (var exerciseViewModel in viewModel.Exercises)
            {
                var trackExercise = trackToUpdate.TrackExercises
                    .FirstOrDefault(te => te.ForeignExerciseID == exerciseViewModel.ExerciseID);

                if (trackExercise != null)
                {
                    // Update existing trackExercise
                    trackExercise.TrackExercisePositionX = exerciseViewModel.ExercisePositionX;
                    trackExercise.TrackExercisePositionY = exerciseViewModel.ExercisePositionY;
                }
                else if (await _context.Exercises.AnyAsync(e => e.ExerciseID == exerciseViewModel.ExerciseID))
                {
                    // Add new trackExercise if it doesn't exist and the exercise is valid
                    trackToUpdate.TrackExercises.Add(new TrackExercise
                    {
                        ForeignTrackID = trackToUpdate.TrackID, // This sets the relationship
                        ForeignExerciseID = exerciseViewModel.ExerciseID,
                        TrackExercisePositionX = exerciseViewModel.ExercisePositionX,
                        TrackExercisePositionY = exerciseViewModel.ExercisePositionY
                    });
                }
            }
            // Save changes to the database
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteTrack/{id}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var track = await _context.Tracks
                .Include(t => t.TrackExercises)  // If you store related data that also needs to be deleted
                .FirstOrDefaultAsync(t => t.TrackID == id);

            if (track == null)
            {
                return NotFound($"Track with ID {id} not found.");
            }

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
            return Ok($"Track with ID {id} has been deleted.");
        }

    }
}

