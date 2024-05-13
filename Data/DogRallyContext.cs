using DogRallyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DogRallyAPI.Data
{
    public class DogRallyContext : DbContext
    {
        // Database context
        public DogRallyContext(DbContextOptions<DogRallyContext> options) : base(options)
        {

        }

        // Database tables
        public DbSet<DogRallyAPI.Models.Exercise> Exercises { get; set; } = default!;
        public DbSet<DogRallyAPI.Models.Track> Tracks { get; set; } = default!;
        public DbSet<DogRallyAPI.Models.TrackExercise> TrackExercises { get; set; } = default!;
        public DbSet<DogRallyAPI.Models.TrackExerciseDTO> TrackExerciseDTOS { get; set; } = default!;

        // Database tablenames override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<Track>().ToTable("Track");
            modelBuilder.Entity<TrackExercise>().ToTable("TrackExercise");

          

            modelBuilder.Entity<TrackExercise>()
                .HasKey(te => new { te.ForeignTrackID, te.ForeignExerciseID });  // Composite primary key


            modelBuilder.Entity<TrackExerciseDTO>()
                .HasKey(te => new { te.ForeignTrackID, te.ForeignExerciseID });  // Composite primary key

            modelBuilder.Entity<TrackExercise>()
                .HasOne(te => te.Track)
                .WithMany(t => t.TrackExercises)
                .HasForeignKey(te => te.ForeignTrackID)
                .OnDelete(DeleteBehavior.Cascade);  // Ensure cascading delete is configured as needed

            modelBuilder.Entity<TrackExercise>()
                .HasOne(te => te.Exercise)
                .WithMany(e => e.TrackExercises)
                .HasForeignKey(te => te.ForeignExerciseID)
                .OnDelete(DeleteBehavior.Cascade);  // Ensure cascading delete is configured as needed
           
            //Get data from view
            modelBuilder.Entity<TrackExerciseDTO>().ToView("TrackExerciseView");
        }
    }
}
