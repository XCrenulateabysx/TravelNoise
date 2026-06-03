using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{
    [Route("api/Theory")]
    [ApiController]
    public class TheoryPageController : ControllerBase
    {
        private readonly RESTAPIContext _context;

        public TheoryPageController(RESTAPIContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheoryPages>>> Get()
        {
            var TheoryPages = await _context.TheoryPages.ToListAsync();
            Console.WriteLine("Poooop");
            return Ok(TheoryPages);
        }

        [HttpGet("yeet")]
        public async Task<ActionResult<IEnumerable<User>>> GetTest()
        {
            var TheoryPages = await _context.Users.ToListAsync();
            Console.WriteLine("Poooop");
            return Ok(TheoryPages);
        }
        [HttpGet("dump")]
        public async Task<IActionResult> DumpDatabase()
        {
            var users = await _context.Users.ToListAsync();
            var genres = await _context.Genres.ToListAsync();
            var theoryPages = await _context.TheoryPages.ToListAsync();
            var pages = await _context.Pages.ToListAsync();
            var locations = await _context.Locations.ToListAsync();
            var gameDescriptions = await _context.GameDescriptions.ToListAsync();
            var practices = await _context.Practices.ToListAsync();
            var votes = await _context.Votes.ToListAsync();

            var result = new
            {
                Users = users,
                Genres = genres,
                TheoryPages = theoryPages,
                Pages = pages,
                Locations = locations,
                GameDescriptions = gameDescriptions,
                Practices = practices,
                Votes = votes
            };

            return Ok(result);
        }
    }
}
