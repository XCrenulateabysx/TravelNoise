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

            // ---------------- GENRES ----------------
            if (!db.Genres.Any())
            {
                db.Genres.AddRange(
                    new Genre
                    {
                        genrename = "Adventure",
                        genreTitle = "Jazz",
                        genreDescription = "A cool Jazz description"
                    },
                    new Genre
                    {
                        genrename = "Puzzle",
                        genreTitle = "Rock",
                        genreDescription = "A cool Rock description"
                    },
                    new Genre
                    {
                        genrename = "Racing",
                        genreTitle = "Country",
                        genreDescription = "A cool Country description"
                    }
                );
                db.SaveChanges();
            }

            var genres = db.Genres
                .AsNoTracking()
                .ToDictionary(g => g.genrename!, g => g.id);

            // ---------------- IMAGES ----------------
            if (!db.Images.Any())
            {
                db.Images.AddRange(
                    new Image { ImageURL = "http://10.0.2.2:5035/images/WTTTTTTTTTF.png" }
                );
                db.SaveChanges();
            }

            var image = db.Images.First();

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

            // ---------------- THEORY PAGES (FIXED RELATIONSHIP) ----------------
            if (!db.TheoryPages.Any())
            {
                db.TheoryPages.AddRange(
                    new TheoryPages
                    {
                        title = "Physics Basics",
                        description = "Understanding movement in games",
                        category = "Harmony",
                        genreId = genres["Adventure"]   // ✅ FIXED
                    },
                    new TheoryPages
                    {
                        title = "AI Behavior",
                        description = "How game AI reacts to players",
                        category = "Instruments",
                        genreId = genres["Puzzle"]      // ✅ FIXED
                    },
                    new TheoryPages
                    {
                        title = "Level Design",
                        description = "Designing engaging game levels",
                        category = "Rhythm",
                        genreId = genres["Racing"]      // fixed spelling too
                    },
                    new TheoryPages
                    {
                        title = "Harmony Basics",
                        description = "Understanding chords and structure",
                        category = "Chords",
                        genreId = genres["Adventure"]
                    }
                );
                db.SaveChanges();
            }

            var theoryPages = db.TheoryPages
                .AsNoTracking()
                .ToDictionary(tp => tp.title!, tp => tp.id);

            // ---------------- PAGES ----------------
            if (!db.Pages.Any())
            {
                db.Pages.AddRange(
                    new Page
                    {
                        PageTitle = "Adventure Guide",
                        PageDescription = "Adventure gameplay guide",
                        userid = admin.Id,
                    },
                    new Page
                    {
                        PageTitle = "Puzzle Guide",
                        PageDescription = "Puzzle solving techniques",
                        userid = player1.Id,
                    },
                    new Page
                    {
                        PageTitle = "Racing Guide",
                        PageDescription = "Racing mechanics explained",
                        userid = tester.Id,
                    }
                );
                db.SaveChanges();
            }

            var pages = db.Pages
                .AsNoTracking()
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
                        pageid = pages["Adventure Guide"],
                    },
                    new Location
                    {
                        RegionName = "Flevoland",
                        RegionDescription = "Logic challenges",
                        genreid = genres["Puzzle"],
                        buttonX = "205dp",
                        buttonY = "235dp",
                        pageid = pages["Puzzle Guide"],
                    },
                    new Location
                    {
                        RegionName = "Noord-Holland",
                        RegionDescription = "Speed and competition",
                        genreid = genres["Racing"],
                        buttonX = "130dp",
                        buttonY = "220dp",
                        pageid = pages["Racing Guide"],
                    }
                );
                db.SaveChanges();
            }

            // ---------------- GAME DESCRIPTIONS ----------------
            if (!db.GameDescriptions.Any())
            {
                db.GameDescriptions.AddRange(
                    new GameDescription { genreid = genres["Adventure"] },
                    new GameDescription { genreid = genres["Puzzle"] },
                    new GameDescription { genreid = genres["Racing"] }
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
        }
    }
}