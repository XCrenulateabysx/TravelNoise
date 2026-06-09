using Microsoft.EntityFrameworkCore;

namespace RESTAPI.Models
{
    public static class DbSeeder
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<RESTAPIContext>();

            db.Database.Migrate();

            // ---------------- USERS ----------------
            if (!db.Users.Any())
            {
                db.Users.AddRange(
                    new User { Username = "admin", Password = "hash_admin" },
                    new User { Username = "player1", Password = "hash_player1" },
                    new User { Username = "tester", Password = "hash_tester" }
                );
                db.SaveChanges();
            }

            var admin = db.Users.First(u => u.Username == "admin");
            var player1 = db.Users.First(u => u.Username == "player1");
            var tester = db.Users.First(u => u.Username == "tester");

            // ---------------- GENRES ----------------
            if (!db.Genres.Any())
            {
                db.Genres.AddRange(
                    new Genre { genrename = "Adventure", genreTitle = "Jazz", genreDescription = "A cool Jazz description" },
                    new Genre { genrename = "Puzzle", genreTitle = "Rock", genreDescription = "A cool Rock description" },
                    new Genre { genrename = "Racing", genreTitle = "Country", genreDescription = "A cool Country description" }
                );
                db.SaveChanges();
            }

            var genres = db.Genres.AsNoTracking()
                .ToDictionary(g => g.genrename!, g => g.id);

            // ---------------- PAGES ----------------
            if (!db.Pages.Any())
            {
                db.Pages.AddRange(
                    new Page { PageTitle = "Adventure Guide", PageDescription = "Adventure gameplay guide", userid = admin.Id },
                    new Page { PageTitle = "Puzzle Guide", PageDescription = "Puzzle solving techniques", userid = player1.Id },
                    new Page { PageTitle = "Racing Guide", PageDescription = "Racing mechanics explained", userid = tester.Id }
                );
                db.SaveChanges();
            }

            var pages = db.Pages.AsNoTracking()
                .ToDictionary(p => p.PageTitle!, p => p.Id);

            // ---------------- PAGE GENRES ----------------
            if (!db.PageGenres.Any())
            {
                db.PageGenres.AddRange(
                    new PageGenre { PageId = pages["Adventure Guide"], GenreId = genres["Adventure"] },
                    new PageGenre { PageId = pages["Puzzle Guide"], GenreId = genres["Puzzle"] },
                    new PageGenre { PageId = pages["Racing Guide"], GenreId = genres["Racing"] }
                );
                db.SaveChanges();
            }

            // ---------------- THEORY PAGES ----------------
            if (!db.TheoryPages.Any())
            {
                db.TheoryPages.AddRange(
                    new TheoryPages { title = "Physics Basics", description = "Movement", category = "Harmony", genreId = genres["Adventure"] },
                    new TheoryPages { title = "AI Behavior", description = "Game AI", category = "Instruments", genreId = genres["Puzzle"] },
                    new TheoryPages { title = "Level Design", description = "Game levels", category = "Rhythm", genreId = genres["Racing"] },
                    new TheoryPages { title = "Harmony Basics", description = "Chord theory", category = "Chords", genreId = genres["Adventure"] }
                );
                db.SaveChanges();
            }

            // ---------------- LOCATIONS ----------------
            if (!db.Locations.Any())
            {
                db.Locations.AddRange(
                    new Location
                    {
                        RegionName = "Utrecht",
                        RegionDescription = "A very cool description",
                        genreid = genres["Adventure"],
                        buttonX = "178dp",
                        buttonY = "300dp",
                        pageid = pages["Adventure Guide"]
                    },
                    new Location
                    {
                        RegionName = "Flevoland",
                        RegionDescription = "Logic challenges",
                        genreid = genres["Puzzle"],
                        buttonX = "205dp",
                        buttonY = "235dp",
                        pageid = pages["Puzzle Guide"]
                    },
                    new Location
                    {
                        RegionName = "Noord-Holland",
                        RegionDescription = "Speed and competition",
                        genreid = genres["Racing"],
                        buttonX = "130dp",
                        buttonY = "220dp",
                        pageid = pages["Racing Guide"]
                    }
                );
                db.SaveChanges();
            }

            // ---------------- PRACTICE ----------------
            if (!db.Practices.Any())
            {
                db.Practices.AddRange(
                    new Practice { practicetype = 1, pageid = pages["Adventure Guide"] },
                    new Practice { practicetype = 2, pageid = pages["Puzzle Guide"] },
                    new Practice { practicetype = 3, pageid = pages["Racing Guide"] }
                );
                db.SaveChanges();
            }

            // ---------------- VOTES ----------------
            if (!db.Votes.Any())
            {
                db.Votes.AddRange(
                    new Vote { UserId = admin.Id, pageid = pages["Adventure Guide"] },
                    new Vote { UserId = player1.Id, pageid = pages["Puzzle Guide"] },
                    new Vote { UserId = tester.Id, pageid = pages["Racing Guide"] }
                );
                db.SaveChanges();
            }

            // ---------------- MUSIC EXERCISES ----------------
            if (!db.MusicExercises.Any())
            {
                db.MusicExercises.AddRange(
                    new MusicExercise { type = "Rhythm", question = "Pick the correct rhythm", videoUrl = "dQw4w9WgXcQ" },
                    new MusicExercise { type = "Chords", question = "Pick the correct chord", videoUrl = "dQw4w9WgXcQ" },
                    new MusicExercise { type = "Harmony", question = "Pick the correct harmony", videoUrl = "dQw4w9WgXcQ" },
                    new MusicExercise { type = "Instruments", question = "Identify the instrument", videoUrl = "dQw4w9WgXcQ" }
                );
                db.SaveChanges();
            }

            var exercises = db.MusicExercises.AsNoTracking()
                .ToDictionary(e => e.type, e => e.id);

            // ---------------- MUSIC EXERCISE OPTIONS ----------------
            if (!db.MusicExerciseOptions.Any())
            {
                db.MusicExerciseOptions.AddRange(
                    new MusicExerciseOptions { Text = "Rhythm A", IsCorrect = true, MusicExerciseId = exercises["Rhythm"] },
                    new MusicExerciseOptions { Text = "Chords A", IsCorrect = true, MusicExerciseId = exercises["Chords"] },
                    new MusicExerciseOptions { Text = "Harmony A", IsCorrect = true, MusicExerciseId = exercises["Harmony"] },
                    new MusicExerciseOptions { Text = "Instrument A", IsCorrect = true, MusicExerciseId = exercises["Instruments"] }
                );
                db.SaveChanges();
            }

            var options = db.MusicExerciseOptions.AsNoTracking().ToList();

            // ---------------- IMAGES (UPDATED WITH musicExerciseOptionsId) ----------------
            if (!db.Images.Any())
            {
                db.Images.AddRange(
                    new Image
                    {
                        ImageURL = "http://10.0.2.2:5035/images/WTTTTTTTTTF.png",
                        pagesId = pages["Adventure Guide"]
                    },

                    new Image
                    {
                        ImageURL = "http://10.0.2.2:5035/images/Exercises/Rhythm/test4.png",
                        musicExerciseOptionsId = options.First(x => x.MusicExerciseId == exercises["Rhythm"]).id
                    },
                    new Image
                    {
                        ImageURL = "http://10.0.2.2:5035/images/Exercises/Chords/test1.png",
                        musicExerciseOptionsId = options.First(x => x.MusicExerciseId == exercises["Chords"]).id
                    },
                    new Image
                    {
                        ImageURL = "http://10.0.2.2:5035/images/Exercises/Harmony/test2.png",
                        musicExerciseOptionsId = options.First(x => x.MusicExerciseId == exercises["Harmony"]).id
                    },
                    new Image
                    {
                        ImageURL = "http://10.0.2.2:5035/images/Exercises/Instruments/test3.png",
                        musicExerciseOptionsId = options.First(x => x.MusicExerciseId == exercises["Instruments"]).id
                    }
                );

                db.SaveChanges();
            }
        }
    }
}