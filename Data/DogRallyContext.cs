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

        // Database tablenames override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<Track>().ToTable("Track");
            modelBuilder.Entity<TrackExercise>().ToTable("TrackExercise");

            // Map the relationships
            modelBuilder.Entity<Track>()
            .HasMany(t => t.Exercises)
            .WithMany(e => e.Tracks)
            .UsingEntity<TrackExercise>(
            j => j
                .HasOne<Exercise>()
                .WithMany()
                .HasForeignKey(ce => ce.ExerciseID),
            j => j
                .HasOne<Track>()
                .WithMany()
                .HasForeignKey(ce => ce.TrackID),
            j =>
            {
                j.Property(te => te.TrackExercisePositionX).HasDefaultValue(0); 
                j.Property(te => te.TrackExercisePositionY).HasDefaultValue(0);
                j.HasKey(te => new { te.TrackID, te.ExerciseID }); // Define composite primary key
                j.ToTable("TrackExercise");
            });

            //Get data from view
            modelBuilder.Entity<TrackExercise>().ToView("DRTrackExerciseView");
        }
    }
}
