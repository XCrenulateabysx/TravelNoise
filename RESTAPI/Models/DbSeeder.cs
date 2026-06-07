using Microsoft.EntityFrameworkCore;

namespace RESTAPI.Models
{
    public static class DbSeeder
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<RESTAPIContext>();
            var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();

            db.Database.Migrate();

            // ONLY RESET IN DEVELOPMENT
            var resetSeed = false;

            if (resetSeed)
            {
                db.Votes.RemoveRange(db.Votes);
                db.Practices.RemoveRange(db.Practices);
                db.Pages.RemoveRange(db.Pages);
                db.GameDescriptions.RemoveRange(db.GameDescriptions);
                db.Locations.RemoveRange(db.Locations);
                db.TheoryPages.RemoveRange(db.TheoryPages);
                db.Genres.RemoveRange(db.Genres);
                db.Users.RemoveRange(db.Users);

                db.SaveChanges();
            }

            // =========================
            // GENRES
            // =========================
            if (!db.Genres.Any())
            {
                db.Genres.AddRange(
                    new Genre { genrename = "Adventure" },
                    new Genre { genrename = "Puzzle" },
                    new Genre { genrename = "Racing" }
                );
                db.SaveChanges();
            }

            var genreMap = db.Genres
                .AsNoTracking()
                .ToDictionary(g => g.genrename!, g => g.id);

            // =========================
            // USERS
            // =========================
            if (!db.Users.Any())
            {
                db.Users.AddRange(
                    new User { Username = "admin", Password = "$2a$11$hash_admin" },
                    new User { Username = "player1", Password = "$2a$11$hash_player1" },
                    new User { Username = "tester", Password = "$2a$11$hash_tester" }
                );
                db.SaveChanges();
            }

            var admin = db.Users.First(u => u.Username == "admin");
            var player1 = db.Users.First(u => u.Username == "player1");
            var tester = db.Users.First(u => u.Username == "tester");

            // =========================
            // THEORY PAGES
            // =========================
            if (!db.TheoryPages.Any())
            {
                db.TheoryPages.AddRange(
                    new TheoryPages
                    {
                        title = "Physics Basics",
                        description = "Understanding movement in games",
                    },
                    new TheoryPages
                    {
                        title = "AI Behavior",
                        description = "How game AI reacts to players",
                    },
                    new TheoryPages
                    {
                        title = "Level Design",
                        description = "Designing engaging game levels",
                    }
                );
                db.SaveChanges();
            }

            // =========================
            // LOCATIONS
            // =========================
            if (!db.Locations.Any())
            {
                db.Locations.AddRange(
                    new Location
                    {
                        RegionName = "Utrecht",
                        RegionDescription = "A very cool description",
                        genreid = genreMap["Adventure"],
                        buttonX = "188dp",
                        buttonY = "360dp",
                        
                    },
                    new Location
                    {
                        RegionName = "Puzzle Region",
                        RegionDescription = "Logic challenges",
                        genreid = genreMap["Puzzle"],
                        buttonX = "200dp",
                        buttonY = "200dp"
                    },
                    new Location
                    {
                        RegionName = "Racing Region",
                        RegionDescription = "Speed and competition",
                        genreid = genreMap["Racing"],
                        buttonX = "100dp",
                        buttonY = "200dp"
                    }
                );
                db.SaveChanges();
            }

            // =========================
            // GAME DESCRIPTIONS
            // =========================
            if (!db.GameDescriptions.Any())
            {
                db.GameDescriptions.AddRange(
                    new GameDescription { genreid = genreMap["Adventure"] },
                    new GameDescription { genreid = genreMap["Puzzle"] },
                    new GameDescription { genreid = genreMap["Racing"] }
                );
                db.SaveChanges();
            }

            // =========================
            // PAGES
            // =========================
            if (!db.Pages.Any())
            {
                db.Pages.AddRange(
                    new Page
                    {
                        PageTitle = "Adventure Guide",
                        PageDescription = "Adventure gameplay guide",
                        userid = admin.Id,
                        genreid = genreMap["Adventure"]
                    },
                    new Page
                    {
                        PageTitle = "Puzzle Guide",
                        PageDescription = "Puzzle solving techniques",
                        userid = player1.Id,
                        genreid = genreMap["Puzzle"]
                    },
                    new Page
                    {
                        PageTitle = "Racing Guide",
                        PageDescription = "Racing mechanics explained",
                        userid = tester.Id,
                        genreid = genreMap["Racing"]
                    }
                );
                db.SaveChanges();
            }

            // =========================
            // PRACTICES
            // =========================
            if (!db.Practices.Any())
            {
                var pageMap = db.Pages
                    .AsNoTracking()
                    .ToDictionary(p => p.PageTitle, p => p.Id);

                db.Practices.AddRange(
                    new Practice { practicetype = 1, pageid = pageMap["Adventure Guide"] },
                    new Practice { practicetype = 2, pageid = pageMap["Puzzle Guide"] },
                    new Practice { practicetype = 3, pageid = pageMap["Racing Guide"] }
                );
                db.SaveChanges();
            }

            // =========================
            // VOTES
            // =========================
            if (!db.Votes.Any())
            {
                var pageMap = db.Pages
                    .AsNoTracking()
                    .ToDictionary(p => p.PageTitle, p => p.Id);

                db.Votes.AddRange(
                    new Vote { UserId = admin.Id, pageid = pageMap["Adventure Guide"] },
                    new Vote { UserId = player1.Id, pageid = pageMap["Puzzle Guide"] },
                    new Vote { UserId = tester.Id, pageid = pageMap["Racing Guide"] }
                );
                db.SaveChanges();
            }
        }
    }
}