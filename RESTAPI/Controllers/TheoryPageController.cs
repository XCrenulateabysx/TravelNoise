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
            return Ok(TheoryPages);
        }

        [HttpGet("GetPage/{id}/{category}")]
        public async Task<ActionResult<IEnumerable<TheoryPages>>> GetTheoryPage(int id, string category)
        {
            var TheoryPageInfo = await _context.TheoryPages.Where(tp => tp.genreId == id && tp.category == category).Include(tp => tp.images).FirstOrDefaultAsync();
            return Ok(TheoryPageInfo);
        }


    }
}
