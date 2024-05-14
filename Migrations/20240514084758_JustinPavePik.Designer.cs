﻿// <auto-generated />
using System;
using DogRallyAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DogRallyAPI.Migrations
{
    [DbContext(typeof(DogRallyContext))]
    [Migration("20240514084758_JustinPavePik")]
    partial class JustinPavePik
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DogRallyAPI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DogRallyAPI.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseID"));

                    b.Property<int>("ExerciseClassEnumID")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseIllustrationPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExerciseMovementEnumID")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ExercisePositionX")
                        .HasColumnType("float");

                    b.Property<double>("ExercisePositionY")
                        .HasColumnType("float");

                    b.Property<bool>("ExerciseSideShift")
                        .HasColumnType("bit");

                    b.Property<int>("ExerciseSignNumber")
                        .HasColumnType("int");

                    b.HasKey("ExerciseID");

                    b.ToTable("Exercise", (string)null);
                });

            modelBuilder.Entity("DogRallyAPI.Models.Track", b =>
                {
                    b.Property<int>("TrackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackID"));

                    b.Property<DateTime>("TrackDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrackID");

                    b.ToTable("Track", (string)null);
                });

            modelBuilder.Entity("DogRallyAPI.Models.TrackExercise", b =>
                {
                    b.Property<int>("ForeignTrackID")
                        .HasColumnType("int");

                    b.Property<int>("ForeignExerciseID")
                        .HasColumnType("int");

                    b.Property<double>("TrackExercisePositionX")
                        .HasColumnType("float");

                    b.Property<double>("TrackExercisePositionY")
                        .HasColumnType("float");

                    b.HasKey("ForeignTrackID", "ForeignExerciseID");

                    b.HasIndex("ForeignExerciseID");

                    b.ToTable("TrackExercise", (string)null);
                });

            modelBuilder.Entity("DogRallyAPI.Models.TrackExerciseDTO", b =>
                {
                    b.Property<int>("ForeignTrackID")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "foreignTrackID");

                    b.Property<int>("ForeignExerciseID")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "foreignExerciseID");

                    b.Property<string>("ExerciseIllustrationPath")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "exerciseIllustrationPath");

                    b.Property<double>("TrackExercisePositionX")
                        .HasColumnType("float")
                        .HasAnnotation("Relational:JsonPropertyName", "trackExercisePositionX");

                    b.Property<double>("TrackExercisePositionY")
                        .HasColumnType("float")
                        .HasAnnotation("Relational:JsonPropertyName", "trackExercisePositionY");

                    b.Property<string>("TrackName")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "trackName");

                    b.HasKey("ForeignTrackID", "ForeignExerciseID");

                    b.ToTable((string)null);

                    b.ToView("TrackExerciseView", (string)null);
                });

            modelBuilder.Entity("ExerciseTrack", b =>
                {
                    b.Property<int>("ExercisesExerciseID")
                        .HasColumnType("int");

                    b.Property<int>("TracksTrackID")
                        .HasColumnType("int");

                    b.HasKey("ExercisesExerciseID", "TracksTrackID");

                    b.HasIndex("TracksTrackID");

                    b.ToTable("ExerciseTrack");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DogRallyAPI.Models.TrackExercise", b =>
                {
                    b.HasOne("DogRallyAPI.Models.Exercise", "Exercise")
                        .WithMany("TrackExercises")
                        .HasForeignKey("ForeignExerciseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogRallyAPI.Models.Track", "Track")
                        .WithMany("TrackExercises")
                        .HasForeignKey("ForeignTrackID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("ExerciseTrack", b =>
                {
                    b.HasOne("DogRallyAPI.Models.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesExerciseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogRallyAPI.Models.Track", null)
                        .WithMany()
                        .HasForeignKey("TracksTrackID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DogRallyAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DogRallyAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogRallyAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DogRallyAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DogRallyAPI.Models.Exercise", b =>
                {
                    b.Navigation("TrackExercises");
                });

            modelBuilder.Entity("DogRallyAPI.Models.Track", b =>
                {
                    b.Navigation("TrackExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
