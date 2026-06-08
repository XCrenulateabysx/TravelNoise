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

            if (!db.Genres.Any())
            {
                db.Genres.AddRange(
                    new Genre { genrename = "Adventure" },
                    new Genre { genrename = "Puzzle" },
                    new Genre { genrename = "Racing" }
                );
                db.SaveChanges();
            }

            var genres = db.Genres.AsNoTracking()
                .ToDictionary(g => g.genrename!, g => g.id);

            if (!db.Images.Any())
            {
                db.Images.AddRange(
                    new Image { ImageURL = "http://10.0.2.2:5035/images/WTTTTTTTTTF.png" }
                );
                db.SaveChanges();
            }

            var image = db.Images.First();

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

            if (!db.TheoryPages.Any())
            {
                db.TheoryPages.AddRange(
                    new TheoryPages
                    {
                        title = "Physics Basics",
                        description = "Understanding movement in games",
                        imageid = image.Id
                    },
                    new TheoryPages
                    {
                        title = "AI Behavior",
                        description = "How game AI reacts to players",
                        imageid = image.Id
                    },
                    new TheoryPages
                    {
                        title = "Level Design",
                        description = "Designing engaging game levels",
                        imageid = image.Id
                    }
                );
                db.SaveChanges();
            }

            if (!db.Pages.Any())
            {
                db.Pages.AddRange(
                    new Page
                    {
                        PageTitle = "Adventure Guide",
                        PageDescription = "Adventure gameplay guide",
                        userid = admin.Id,
                        imageid = image.Id
                    },
                    new Page
                    {
                        PageTitle = "Puzzle Guide",
                        PageDescription = "Puzzle solving techniques",
                        userid = player1.Id,
                        imageid = image.Id
                    },
                    new Page
                    {
                        PageTitle = "Racing Guide",
                        PageDescription = "Racing mechanics explained",
                        userid = tester.Id,
                        imageid = image.Id
                    }
                );
                db.SaveChanges();
            }

            var pages = db.Pages.AsNoTracking()
                .ToDictionary(p => p.PageTitle!, p => p.Id);

            if (!db.PageGenres.Any())
            {
                db.PageGenres.AddRange(
                    new PageGenre { PageId = pages["Adventure Guide"], GenreId = genres["Adventure"] },
                    new PageGenre { PageId = pages["Puzzle Guide"], GenreId = genres["Puzzle"] },
                    new PageGenre { PageId = pages["Racing Guide"], GenreId = genres["Racing"] }
                );
                db.SaveChanges();
            }

            if (!db.Locations.Any())
            {
                db.Locations.AddRange(
                    new Location
                    {
                        RegionName = "Utrecht",
                        RegionDescription = "A very cool description",
                        genreid = genres["Adventure"],
                        buttonX = "188dp",
                        buttonY = "360dp",
                        pageid = pages["Adventure Guide"],
                        imageid = image.Id
                    },
                    new Location
                    {
                        RegionName = "Puzzle Region",
                        RegionDescription = "Logic challenges",
                        genreid = genres["Puzzle"],
                        buttonX = "200dp",
                        buttonY = "200dp",
                        pageid = pages["Puzzle Guide"],
                        imageid = image.Id
                    },
                    new Location
                    {
                        RegionName = "Racing Region",
                        RegionDescription = "Speed and competition",
                        genreid = genres["Racing"],
                        buttonX = "100dp",
                        buttonY = "200dp",
                        pageid = pages["Racing Guide"],
                        imageid = image.Id
                    }
                );
                db.SaveChanges();
            }

            if (!db.GameDescriptions.Any())
            {
                db.GameDescriptions.AddRange(
                    new GameDescription { genreid = genres["Adventure"] },
                    new GameDescription { genreid = genres["Puzzle"] },
                    new GameDescription { genreid = genres["Racing"] }
                );
                db.SaveChanges();
            }

            if (!db.Practices.Any())
            {
                db.Practices.AddRange(
                    new Practice { practicetype = 1, pageid = pages["Adventure Guide"] },
                    new Practice { practicetype = 2, pageid = pages["Puzzle Guide"] },
                    new Practice { practicetype = 3, pageid = pages["Racing Guide"] }
                );
                db.SaveChanges();
            }

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