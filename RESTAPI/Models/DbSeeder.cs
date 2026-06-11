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

            // ================= USERS =================
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

            // ================= GENRES =================
            if (!db.Genres.Any())
            {
                db.Genres.AddRange(
                    new Genre
                    {
                        genrename = "Jazz",
                        genreTitle = "Jazz",
                        genreDescription = "Jazz is a complex and expressive genre built on improvisation, swing rhythms, and rich harmonic structures."
                    },
                    new Genre
                    {
                        genrename = "Rock",
                        genreTitle = "Rock",
                        genreDescription = "Rock is a powerful genre driven by electric instruments, strong rhythms, and simple but impactful harmonies."
                    },
                    new Genre
                    {
                        genrename = "Blues",
                        genreTitle = "Blues",
                        genreDescription = "Blues is an emotional genre based on expressive melodies, repetitive structures, and the iconic twelve-bar form."
                    },
                    new Genre
                    {
                        genrename = "Metal",
                        genreTitle = "Metal",
                        genreDescription = "Metal is an intense and aggressive genre characterized by distortion, speed, technical skill, and dark tonalities."
                    }
                );

                db.SaveChanges();
            }

            var genres = db.Genres.AsNoTracking()
                .ToDictionary(g => g.genrename!, g => g.id);

            // ================= PAGES =================
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

            // ================= PAGE GENRES (ALL GENRES PER PAGE) =================
            if (!db.PageGenres.Any())
            {
                foreach (var page in pages)
                {
                    foreach (var genre in genres)
                    {
                        db.PageGenres.Add(new PageGenre
                        {
                            PageId = page.Value,
                            GenreId = genre.Value
                        });
                    }
                }

                db.SaveChanges();
            }

            // ================= THEORY PAGES (YOUR REAL DATA) =================
            if (!db.TheoryPages.Any())
            {
                string img = "http://10.0.2.2:5035/images/WTTTTTTTTTF.png";

                db.TheoryPages.AddRange(

                    // ROCK
                    new TheoryPages { title = "Rock Harmony", description = "Rock harmony generally focuses on strong and accessible chord progressions. Many songs use combinations of the I, IV, V, and vi chords, creating memorable melodies and emotional impact while maintaining a straightforward structure.", category = "Harmony", genreId = genres["Rock"] },
                    new TheoryPages { title = "Rock Instruments", description = "The classic rock band consists of electric guitar, bass guitar, drums, and vocals. Many groups also incorporate keyboards and additional guitars to create fuller and more dynamic arrangements.", category = "Instruments", genreId = genres["Rock"] },
                    new TheoryPages { title = "Rock Rhythm", description = "Rock music relies on a strong and consistent rhythmic foundation. Drums and bass work together to create driving grooves, while guitar rhythms often reinforce the beat and provide energy throughout the song.", category = "Rhythm", genreId = genres["Rock"] },
                    new TheoryPages { title = "Rock Chords", description = "Power chords are a defining characteristic of rock music. These simplified chords provide a powerful and energetic sound that works especially well with electric guitar distortion and amplified performances.", category = "Chords", genreId = genres["Rock"] },

                    // BLUES
                    new TheoryPages { title = "Blues Harmony", description = "Blues harmony is built around the twelve-bar blues progression. The use of dominant seventh chords creates tension and emotional depth, contributing to the expressive character of the genre.", category = "Harmony", genreId = genres["Blues"] },
                    new TheoryPages { title = "Blues Instruments", description = "Electric guitar, harmonica, piano, bass, and drums are common blues instruments. The guitar often takes a leading role, using expressive techniques to imitate the sound of the human voice.", category = "Instruments", genreId = genres["Blues"] },
                    new TheoryPages { title = "Blues Rhythm", description = "The blues is famous for its shuffle rhythm and swing feel. Rather than dividing beats evenly, notes are often played with a long-short pattern that creates a relaxed and flowing groove.", category = "Rhythm", genreId = genres["Blues"] },
                    new TheoryPages { title = "Blues Chords", description = "Most blues songs use only a few chords, typically the I, IV, and V chords. Despite this simplicity, musicians create variety through phrasing, timing, and expressive techniques such as bends and slides.", category = "Chords", genreId = genres["Blues"] },

                    // METAL
                    new TheoryPages { title = "Metal Harmony", description = "Metal harmony often incorporates darker tonalities and dramatic chord progressions. Many subgenres make use of modal scales, chromatic movement, and dissonance to create tension and intensity.", category = "Harmony", genreId = genres["Metal"] },
                    new TheoryPages { title = "Metal Instruments", description = "Metal bands typically feature distorted electric guitars, bass guitar, drums, and vocals. Advanced drumming techniques, technical guitar playing, and high-performance amplification are central to the genre's sound.", category = "Instruments", genreId = genres["Metal"] },
                    new TheoryPages { title = "Metal Rhythm", description = "Metal rhythms range from slow and heavy grooves to extremely fast passages. Techniques such as double bass drumming, palm muting, and syncopated riffs help create the powerful rhythmic drive associated with metal.", category = "Rhythm", genreId = genres["Metal"] },
                    new TheoryPages { title = "Metal Chords", description = "Power chords are heavily used in metal music, often played with high gain and distortion. Fast chord changes and complex riff patterns contribute to the genre's aggressive and energetic sound.", category = "Chords", genreId = genres["Metal"] },

                    // JAZZ
                    new TheoryPages { title = "Jazz Harmony", description = "Jazz harmony is known for its complexity and richness. Musicians frequently use seventh chords, extended chords, and chord substitutions to create colorful sounds. Progressions such as the ii–V–I form the backbone of many jazz compositions and improvisations.", category = "Harmony", genreId = genres["Jazz"] },
                    new TheoryPages { title = "Jazz Instruments", description = "Common jazz instruments include saxophone, trumpet, piano, double bass, drums, and guitar. Each instrument contributes uniquely to the ensemble, often taking turns accompanying and improvising during performances.", category = "Instruments", genreId = genres["Jazz"] },
                    new TheoryPages { title = "Jazz Rhythm", description = "Jazz rhythm emphasizes swing and groove. Notes are often performed with a swung feel rather than straight timing, creating a relaxed yet energetic pulse. Syncopation and rhythmic variation are essential elements of jazz performance.", category = "Rhythm", genreId = genres["Jazz"] },
                    new TheoryPages { title = "Jazz Chords", description = "Jazz chords often contain additional notes beyond simple major and minor triads. Seventh, ninth, eleventh, and thirteenth chords are common and help create the distinctive smooth and sophisticated sound associated with jazz music.", category = "Chords", genreId = genres["Jazz"] }
                );

                db.SaveChanges();

                // IMAGE FOR ALL THEORY PAGES
                var theoryPages = db.TheoryPages.ToList();

                db.Images.AddRange(
                    theoryPages.Select(tp => new Image
                    {
                        ImageURL = img,
                        theorypagesId = tp.id
                    })
                );

                db.SaveChanges();
            }

            // ================= LOCATIONS =================
            if (!db.Locations.Any())
            {
                db.Locations.AddRange(
                    new Location { RegionName = "Utrecht", RegionDescription = "Central testing region covering all musical genres.", buttonX = 0.48f, buttonY = 0.51f },
                    new Location { RegionName = "Flevoland", RegionDescription = "Modern structured region for controlled testing scenarios.", buttonX = 0.58f, buttonY = 0.38f },
                    new Location { RegionName = "Noord-Holland", RegionDescription = "Cultural and diverse region ideal for music exploration.", buttonX = 0.38f, buttonY = 0.30f }
                );

                db.SaveChanges();
            }

            // ================= MUSIC EXERCISES =================
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

            // ================= MUSIC OPTIONS =================
            if (!db.MusicExerciseOptions.Any())
            {
                db.MusicExerciseOptions.AddRange(
                    new MusicExerciseOptions { Text = "Option A", IsCorrect = true, MusicExerciseId = exercises["Rhythm"] },
                    new MusicExerciseOptions { Text = "Option B", IsCorrect = false, MusicExerciseId = exercises["Rhythm"] },

                    new MusicExerciseOptions { Text = "Option A", IsCorrect = true, MusicExerciseId = exercises["Chords"] },
                    new MusicExerciseOptions { Text = "Option B", IsCorrect = false, MusicExerciseId = exercises["Chords"] },

                    new MusicExerciseOptions { Text = "Option A", IsCorrect = true, MusicExerciseId = exercises["Harmony"] },
                    new MusicExerciseOptions { Text = "Option B", IsCorrect = false, MusicExerciseId = exercises["Harmony"] },

                    new MusicExerciseOptions { Text = "Option A", IsCorrect = true, MusicExerciseId = exercises["Instruments"] },
                    new MusicExerciseOptions { Text = "Option B", IsCorrect = false, MusicExerciseId = exercises["Instruments"] }
                );

                db.SaveChanges();

                var options = db.MusicExerciseOptions.ToList();

                db.Images.AddRange(
                    options.Select(o => new Image
                    {
                        ImageURL = "http://10.0.2.2:5035/images/WTTTTTTTTTF.png",
                        musicExerciseOptionsId = o.id
                    })
                );

                db.SaveChanges();
            }
        }
    }
}